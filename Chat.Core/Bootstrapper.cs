using Chat.Entities.Db;
using Ninject;
using Chat.Core.Repository.User;
using Chat.Core.Repsitory.Messages;
using Chat.Core.Repsitory.Groups;

namespace Chat.Core
{
    public class Bootstrapper
    {
        public Bootstrapper()
        {
            Kernel = new StandardKernel();
            InitializeDependencies();
            FillDbIfEmpty();
        }

        public static IKernel Kernel { get; private set; }

        private void InitializeDependencies()
        {
            Kernel.Bind<IDatabaseService>().To<DatabaseService>();
            Kernel.Bind<IUserRepository>().To<UserRepository>();
            Kernel.Bind<IMessageRepository>().To<MessageRepository>();
            Kernel.Bind<IGroupRepository>().To<GroupRepository>();
        }

        private void FillDbIfEmpty()
        {
            var dbService = Kernel.Get<IDatabaseService>();

            dbService.FillDbIfEmpty();
        }
    }
}
