mergeInto(LibraryManager.library, {
  SendAvatarOptions: function(topType, hairColor, skinColor) {
    const tt = UTF8ToString(topType);
    const hc = UTF8ToString(hairColor);
    const sc = UTF8ToString(skinColor);
    if (typeof UpdateAvatarFromUnity !== 'undefined') {
      UpdateAvatarFromUnity(tt, hc, sc);
    }
  },

  ReceiveAvatarImage: function(data) {
    const base64 = UTF8ToString(data);
    SendMessage("AvatarManager", "ReceiveFromWeb", base64);
  }
});
