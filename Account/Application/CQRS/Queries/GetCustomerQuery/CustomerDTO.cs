using Account.Application.Common.Interfaces;
using Account.Models.Domain.Entities;
using AutoMapper;

namespace Account.Application.CQRS.Queries
{
    public class CustomerDTO 
    {
        public Guid Id { get; set; }
        public string CustomerNumber { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
    }
}
