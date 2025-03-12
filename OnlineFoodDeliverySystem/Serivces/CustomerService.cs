﻿using System;
using OnlineFoodDeliverySystem.Data;
using OnlineFoodDeliverySystem.Repository;

namespace OnlineFoodDeliverySystem.Services
{


    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _customerRepository.GetAllCustomersAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            return await _customerRepository.GetCustomerByIdAsync(customerId);
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            await _customerRepository.AddCustomerAsync(customer);
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            await _customerRepository.UpdateCustomerAsync(customer);
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            await _customerRepository.DeleteCustomerAsync(customerId);
        }
    }
}
