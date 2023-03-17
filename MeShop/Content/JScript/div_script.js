function resetHeight() {
   var maxHeight = 0;
   $(".box").height("auto").each(function(){ 
       maxHeight = $(this).height() > maxHeight ? $(this).height() : maxHeight; 
   }).height(maxHeight);
}
resetHeight();
// reset height on resize of the window:
$(window).resize(function() { 
    resetHeight();
});