mergeInto(LibraryManager.library, {
  SendAvatarImage: function (data) {
    var str = UTF8ToString(data);
    SendMessage("AvatarManager", "ReceiveFromWeb", str);
  }
});