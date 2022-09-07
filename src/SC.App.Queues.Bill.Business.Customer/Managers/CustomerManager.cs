using System;
using System.Threading.Tasks;
using SC.App.Queues.Bill.Business.Customer.Managers.Interface;
using SC.App.Queues.Bill.Business.Customer.Repositories.Interface;
using SC.App.Queues.Bill.Common.Exceptions;

namespace SC.App.Queues.Bill.Business.Customer.Managers
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerManager(
            ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task SetToRegularAsync(Guid customerId)
        {
            try
            {
                // Get customer
                var customer = _customerRepository.GetById(customerId);
                if (customer == null)
                {
                    throw new SkipProcessException("No customer found.");
                }

                // Update customer to regular
                customer.IsNew = false;
                customer.UpdatedOn = DateTime.Now;
                _customerRepository.Update(customer);

                await Task.CompletedTask;
            }
            catch
            {
                throw;
            }
        }
    }
}