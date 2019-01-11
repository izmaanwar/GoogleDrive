window.onload=function()
    {
		var b1 = document.getElementById('btnLogin');
		b1.onclick = function(){
			var v1 = document.getElementById('Name');
			var v2 = document.getElementById('Password');
			var v3 = document.getElementById('Login');
			var v4 = document.getElementById('Email');
			var v5 = document.getElementById('gender');
			var v6 = document.getElementById('address');
			var v7= document.getElementById('nic');
			var v8  = document.getElementById('dob');
			var v9 = document.getElementById('PictureName');
			
			
			if(v1.value == ''){
				alert('name cant be empty!');
				return false;
			}
			if(v2.value == ''){
				alert('Password cant be empty!');
				return false;
			} 
			if(v3.value == ''){
				alert('login cant be empty!');
				return false;
			}
			if(v4.value == ''){
				alert('email cant be empty!');
				return false;
			}
			if (v5.value == '') {
			    alert('gender cant be empty!');
			    return false;
			}
			if (v6.value == '') {
			    alert('address cant be empty!');
			    return false;
			}
			if (v7.value == '') {
			    alert('nic cant be empty!');
			    return false;
			}
			if (v8.value == '') {
			    alert('dob cant be empty!');
			    return false;
			}
			if (v9.value == '') {
			    alert('image cant be empty!');
			    return false;
			}
			return true;                               
		};                                            
       	}  
		 
function validate() { 
      if( document.getElementById("name1").value!="")
	  {
		  document.getElementById("name1").value = "";
		  return false;
	  }
        if( document.getElementById("pass1").value!="")
	  {
		  document.getElementById("pass1").value = "";
		  return false;
	  }
        if( document.getElementById("email").value!="")
	  {
		  document.getElementById("email").value = "";
		  return false;
	  }  
        if( document.getElementById("name").value!="")
	  {
		  document.getElementById("name").value = "";
		  return false;
	  }  
  if( document.getElementById("country").value!=0)
	  {
		  document.getElementById("country").value ="--select--";
		  return false;
	  } 
	  if( document.getElementById("admin").value!=0)
	  {
		  document.getElementById("admin").value ="--select--";
		  return false;
	  }
 } 