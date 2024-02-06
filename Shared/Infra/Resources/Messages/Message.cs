#pragma warning disable S1118 // Utility classes should not have public constructors
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
using System.Reflection;

namespace Shared.Infra.Resources.Messages
{
    public class Message
    {
        public Message()
        {
            var keysFields =
                from fieldInfo in typeof(Message).GetProperties(BindingFlags.Public | BindingFlags.Static)
                select fieldInfo;

            foreach (var keyField in keysFields)
            {
                keyField.SetValue(this, keyField.Name.ToArray());
            }
        }

        public static char[] ValueCannotBeNull { get; private set; }
        public static char[] VariableCannotBeNull { get; private set; }
    }
}
