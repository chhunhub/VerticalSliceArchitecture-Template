using SharedKernel;

namespace VerticalSlice.DomainEvents;
public sealed record CreateCustomerDomainEvent(Guid Id) : IDomainEvent;


