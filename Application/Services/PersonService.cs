using FinancesAPI.Application.DTOs;
using FinancesAPI.Domain.Entities;
using FinancesAPI.Domain.Enums;
using FinancesAPI.Domain.Interfaces;

namespace FinancesAPI.Application.Services
{
    public class PersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<IEnumerable<PersonResponseDto>> GetAsync()
        {
            var persons = await _personRepository.GetAsync();

            var result = persons.Select(person => new PersonResponseDto
            {
                Id = person.Id,
                Name = person.Name,
                Age = person.Age
            });

            return result;
        }

        public async Task<PersonResponseDto> CreateAsync(CreatePersonDto createPersonDto)
        {
            if (string.IsNullOrWhiteSpace(createPersonDto.Name))
                throw new Exception("Nome é obrigatório.");

            var person = new Person
            {
                Name = createPersonDto.Name,
                Age = createPersonDto.Age
            };

            await _personRepository.AddAsync(person);
            await _personRepository.SaveChangesAsync();

            return new PersonResponseDto
            {
                Id = person.Id,
                Name = person.Name,
                Age = person.Age
            };
        }
        public async Task<PersonResponseDto> UpdateAsync(Guid id, UpdatePersonDto updatePersonDto)
        {
            var person = await _personRepository.GetByIdAsync(id);

            if (person == null)
                throw new Exception("Pessoa não encontrada.");

            if (string.IsNullOrWhiteSpace(updatePersonDto.Name))
                throw new Exception("Nome é obrigatório.");

            if (updatePersonDto.Name.Length > 200)
                throw new Exception("Nome deve ter no máximo 200 caracteres.");

            person.Name = updatePersonDto.Name;
            person.Age = updatePersonDto.Age;

            await _personRepository.SaveChangesAsync();

            return new PersonResponseDto
            {
                Id = person.Id,
                Name = person.Name,
                Age = person.Age
            };
        }
        public async Task DeleteAsync(Guid id)
        {
            var person = await _personRepository.GetByIdAsync(id);

            if (person == null)
                throw new Exception("Pessoa não encontrada.");

            await _personRepository.DeleteAsync(person);
            await _personRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<PersonTotalsDto>> GetTotalsAsync()
        {
            var persons = await _personRepository.GetWithTransactionsAsync();

            var result = persons.Select(person =>
            {
                var totalIncome = person.Transactions
                    .Where(transaction => transaction.Type == TransactionType.Income)
                    .Sum(transaction => transaction.Value);

                var totalExpense = person.Transactions
                    .Where(transaction => transaction.Type == TransactionType.Expense)
                    .Sum(transaction => transaction.Value);

                return new PersonTotalsDto
                {
                    Name = person.Name,
                    TotalIncome = totalIncome,
                    TotalExpense = totalExpense,
                    Balance = totalIncome - totalExpense
                };
            });

            return result;
        }
    }
}