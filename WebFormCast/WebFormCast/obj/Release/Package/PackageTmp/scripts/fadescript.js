window.addEvent('load', function()
{

if(!document.getElementById("loading"))
return false;

if(document.getElementById("loading").innerHTML=="")
{
document.getElementById("loading").style.display='none';
return false;
}
    
        k = document.getElementById("flag").value;
        if(k==1)
        {
	        var effect3 = new Fx.Style('loading', 'opacity', {duration:8000, wait:true, transition: Fx.Transitions.Quart.easeOut});
	        effect3.start.pass([0], effect3).delay(1000);
	        document.getElementById("flag").value=0;
	    }
	    else
	    {
	        document.getElementById("loading").style.display='none';
	    }
	

});