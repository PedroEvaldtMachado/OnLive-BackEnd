namespace Shared.Infra.Enums
{
    public struct ChannelPermission
    {
        public const ulong None = 0b0;
        public const ulong View = 0b0001;
        public const ulong Edit = 0b0010;
        public const ulong Delete = 0b0100;
        public const ulong HomeEdit = 0b1000;
        public const ulong StreamView = 0b0001_0000;
        public const ulong StreamCreate = 0b0010_0000;
        public const ulong StreamEdit = 0b0100_0000;
        public const ulong StreamDelete = 0b1000_0000;
        public const ulong Researchs = 0b0001_0000_0000;
        public const ulong EmotesEdit = 0b0010_0000_0000;
        public const ulong Sub = 0b0100_0000_0000;

        public const ulong MessageView = 0b0001_0000_0000_0000;
        public const ulong MessageCreate = 0b0010_0000_0000_0000;
        public const ulong MessageDelete = 0b0100_0000_0000_0000;
        public const ulong MessageChatMode = 0b1000_0000_0000_0000;
        public const ulong MessageBan = 0b0001_0000_0000_0000_0000;
        public const ulong MessageTimeout = 0b0010_0000_0000_0000_0000;
        public const ulong MessageAll = MessageView | MessageCreate | MessageDelete | MessageChatMode | MessageBan | MessageTimeout;

        public const ulong PrivateMessageView = 0b0001_0000_0000_0000_0000_0000;
        public const ulong PrivateMessageCreate = 0b0010_0000_0000_0000_0000_0000;
        public const ulong PrivateMessageDelete = 0b0100_0000_0000_0000_0000_0000;
        public const ulong PrivateMessageAll = PrivateMessageView | PrivateMessageCreate | PrivateMessageDelete;

        public const ulong ViewerBase = 0b0001_0000_0000_0000_0000_0000_0000;
        public const ulong SubBase = 0b0010_0000_0000_0000_0000_0000_0000 | ViewerBase;
        public const ulong ArtistBase = 0b0100_0000_0000_0000_0000_0000_0000 | ViewerBase;
        public const ulong ModeratorBase = 0b1000_0000_0000_0000_0000_0000_0000 | ArtistBase;

        public const ulong Viewer = ViewerBase | View | StreamView | MessageView | MessageCreate | PrivateMessageView | PrivateMessageCreate;
        public const ulong Artist = ArtistBase | Viewer | HomeEdit | EmotesEdit;
        public const ulong Moderator = ModeratorBase | Artist | StreamEdit | Researchs | MessageAll | PrivateMessageAll;
        public const ulong Admin = Moderator | Edit | StreamCreate | StreamDelete;
        public const ulong Owner = Delete | Admin;
    }
}
