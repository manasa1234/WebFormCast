function getContent(url){
	var XMLhttpObj = false;
    
    if (typeof XMLHttpRequest != 'undefined'){
        XMLhttpObj = new XMLHttpRequest();
    } else if (window.ActiveXObject){
        	try{
            	XMLhttpObj = new ActiveXObject('Msxml2.XMLHTTP');
        	} catch(e) {
            		try{
                		XMLhttpObj = new ActiveXObject('Microsoft.XMLHTTP');
            		} catch(e) {}
        	}
    }

    if (!XMLhttpObj) return;
	
	var mytime= "&ms="+ new Date().getTime();
	
	XMLhttpObj.onreadystatechange = function() {
    	if (XMLhttpObj.readyState == 4)
			{ 
				response_content = XMLhttpObj.responseText;
				//alert(response_content);
        }
    }
    url = url + mytime;
    XMLhttpObj.open('GET', url, true);
    XMLhttpObj.send(null);
}

function getSession()
{
   getContent("../getsession.aspx?");
   setTimeout("getSession()",1000*60*1);
}
getSession();
