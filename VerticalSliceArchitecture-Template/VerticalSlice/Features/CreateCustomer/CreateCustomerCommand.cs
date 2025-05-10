using SharedKernel;

namespace VerticalSlice.Features.CreateCustomer;
public sealed record CreateCustomerCommand(string firstName, string lastName, string email, string address, string phonenumber) : ICommand<Guid>;


