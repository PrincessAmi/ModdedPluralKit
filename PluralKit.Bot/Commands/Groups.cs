using System.Threading.Tasks;

using Dapper;

using PluralKit.Core;

namespace PluralKit.Bot
{
    public class Groups
    {
        private IDataStore _data;
        private DbConnectionFactory _db;
        
        public Groups(IDataStore data, DbConnectionFactory db)
        {
            _data = data;
            _db = db;
        }

        public async Task GroupNew(Context ctx)
        {
            ctx.CheckSystem();
            
            if (!ctx.HasNext()) throw new PKSyntaxError("You must provide a group name.");
            var groupName = ctx.RemainderOrNull();
            
            // Name length cap
            if (groupName.Length > Limits.MaxGroupNameLength) throw Errors.GroupNameTooLongError(groupName.Length);

            // Create the group
            var group = await _data.CreateGroup(ctx.System, groupName);
            await ctx.Reply($"{Emojis.Success} Group \"{groupName.SanitizeMentions()}\" (`{group.Hid}`) registered! Add a member to it using `pk;group {group.Name.SanitizeMentions()} add <members>`.");
        }
    }
}