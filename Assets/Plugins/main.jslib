mergeInto(LibraryManager.library, {

  ShowAdv : function(){
      ysdk.adv.showFullscreenAdv({
  callbacks: {
      onClose: function(wasShown) {
      },
      onError: function(error) {
        // some action on error
      },
      onOpen: () => {
      },
      }
      })
  },

});