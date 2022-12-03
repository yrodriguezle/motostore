using GraphQL;
using GraphQL.Types;

using Motostore.Models;
using Motostore.Repositories;
using Motostore.Helpers;

namespace Motostore.GraphQL
{
    public class MotostoreMutations : ObjectGraphType
    {
        private IEventMessageStack _eventMessagesStack;
        public MotostoreMutations(Defer<IRepository> repository, IEventMessageStack eventMessagesStack)
        {
            _eventMessagesStack = eventMessagesStack;

            Field<AccountMutationsGroup>("account").Resolve(context => new { });

            Field<UserType>(Name = "AddOrUpdateUser")
                .Argument<NonNullGraphType<UserInputType>>("user")
                .ResolveAsync(async context =>
                {
                    User userFromClient = context.GetArgument<User>("user");
                    User user = await repository.Value.User.AddOrUpdate(userFromClient);
                    _eventMessagesStack.AddEventMessage(new EventMessage
                    {
                        Id = Guid.NewGuid().ToString(),
                        Entity = user,
                        SubscriptionName = "userChanged",
                    });
                    return user;
                });
        }
    }
}
