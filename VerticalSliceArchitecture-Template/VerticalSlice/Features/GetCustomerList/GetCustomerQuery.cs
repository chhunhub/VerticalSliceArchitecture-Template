using SharedKernel;

namespace VerticalSlice.Features.GetCustomerList;
public sealed record GetCustomerQuery() : IQuery<IReadOnlyList<CustomerResponse>>;

