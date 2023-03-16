var imgs = document.getElementsByTagName('img');
var radio = document.getElementsByClassName('radio')[0];
var prv = document.getElementsByClassName('prv')[0];
var nxt = document.getElementsByClassName('nxt')[0];
var imgCont = document.getElementsByClassName('images')[0];
var move = 0;
var imgWidth = 700;

//to Create the Circles
for(let i=0; i<imgs.length; i++) {

    var btn = document.createElement('span');
    btn.classList.add('circle');
    radio.appendChild(btn);

    //to Move the Carousal
    btn.onclick = function() {
        move = -(i)*imgWidth;
        imgCont.style.left = move + 'px';
    }        
    
}

//Previous Button
   prv.onclick = function() {
        console.log(move)
       move+= imgWidth; 
        if(move < imgWidth) {
            imgCont.style.left = move + 'px';
        }
        else {
            console.log('cnnt move');
            move = 0;
        }
       
    }
    
//Next Button   
    nxt.onclick = function() {
       
        move-= imgWidth;
        if(move > -(imgs.length*imgWidth)){
            imgCont.style.left = move + 'px';
        }
        else {
            console.log('cnnt move');
            move = -(imgs.length*imgWidth)+imgWidth;
        }
        
    }
    
//Autoplay functions    
function autoplay() {
     move-= imgWidth;
    if(move > -(imgs.length*imgWidth)){
             
        imgCont.style.left = move + 'px';
         }
    else {
            move = 0;
        imgCont.style.left = move + 'px';
         }
        
        
} 

//Calls autoplay after ever 3.0s
    setInterval(autoplay,3000);