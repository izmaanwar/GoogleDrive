#include<iostream>
using namespace std;
class array1
{    private:
      int **f;
      int r;
	  int c;
	  void arr(int r,int c )
	  { 
		  r=r;
		  c=c;
		  f = new int *[r];
		  for(int i=0;i<r;i=i+1)
		  { 
			  f[i]=new int [c];
		  }
		 
	  }  

    public:
		
		 array1( int r1,int c1)
	  {   
		  r=r1;
		  c=c1;
		  arr(r,c);
	  }
	  array1 ( const array1 &obj)
	  {  
		   r=obj.r;
		   c=obj.c;

			 f=new int *[r];
			  for(int i=0;i<r;i=i+1)
		  { 
			  f[i]=new int [c];
		  }
			for(int i=0;i<r;i=i+1)
			{
				for(int j=0;j<c;j=j+1)
					{

                 f[i][j]=obj.f[i][j];


                 	}
			}

      }

		 void setvalue(int v,int i,int j)
		{
			f[i][j]=v;
		}  

		 int getvalue(int i,int j)
		 {
			 return f[i][j];
		 }
		 void operator=(array1 &obj)
		 {  
			  for(int i=0;i<r;i=i+1)
		    { 
			delete [] f[i];
			f[i]=0;
		    }
			 delete [] f;
			 f=0;
			 r=obj.r;
			 c=obj.c;

			 f=new int *[r];
			  for(int i=0;i<r;i=i+1)
		  { 
			  f[i]=new int [c];
		  }
			for(int i=0;i<r;i=i+1)
			{
				for(int j=0;j<c;j=j+1)
					{

                 f[i][j]=obj.f[i][j];


                 	}
			}

		 }
		   bool  operator>( array1 &obj )
	  {     
		  bool status;
		 for(int i=0;i<r;i=i+1)
		{
				for(int j=0;j<c;j=j+1)
			{

                if( f[i][j]>obj.f[i][j])
				{
				status =true;
				}
				else 
					status =false;
				
			}
	 }
				return status;

	  
		   }
		   	   bool  operator<( array1 &obj )
	  {     
		  bool status;
		 for(int i=0;i<r;i=i+1)
			{
				for(int j=0;j<c;j=j+1)
					{

                if( f[i][j]<obj.f[i][j])
				{
				status =true;
				}
				else 
					status=false;
				
			}
		 }
				return status;

	  
		   }
         bool  operator==( array1 &obj )
	    {     
		  bool status;
		 for(int i=0;i<r;i=i+1)
			{
				for(int j=0;j<c;j=j+1)
					{

                if( f[i][j]==obj.f[i][j])
				{
				status =true;
				}
				else 
					status=false;
				
			}
		 }
				return status;

	  
		   }
		    bool  operator>=( array1 &obj )
	    {     
		  bool status;
		 for(int i=0;i<r;i=i+1)
			{
				for(int j=0;j<c;j=j+1)
					{

                if( f[i][j]>=obj.f[i][j])
				{
				status =true;
				}
				else 
					status=false;
				
			}
		 }
				return status;

	 
		   }
			   bool  operator<=( array1 &obj )
	    {     
		  bool status;
		 for(int i=0;i<r;i=i+1)
			{
				for(int j=0;j<c;j=j+1)
					{

                if( f[i][j]>=obj.f[i][j])
				{
				status =true;
				}
				else 
					status= false;
				
			}
		 }
				return status;

	 
		   }
			   	   bool  operator!=( array1 &obj )
	    {     
		  bool status;
		 for(int i=0;i<r;i=i+1)
			{
				for(int j=0;j<c;j=j+1)
					{

                if( f[i][j]!=obj.f[i][j])
				{
				status =true;
				}
				else 
					status=false;
				
			}
		 }
				return status;

	 
		   }
	 array1   operator++( )
	  {   
		   for(int i=0;i<r;i=i+1)
			{
				for(int j=0;j<c;j=j+1)
					{
						++f[i][j];
			     	}
		   }
		  return *this;
	  }
	   array1   operator++( int )
	   {

		    
		   for(int i=0;i<r;i=i+1)
			{
				for(int j=0;j<c;j=j+1)
					{
						f[i][j]++;
			     	}
		   }
		  return *this;


	   }
	  array1   operator--( )
	   {

		    
		   for(int i=0;i<r;i=i+1)
			{
				for(int j=0;j<c;j=j+1)
					{
						f[i][j]--;
			     	}
		   }
		  return *this;


	   }
	   array1   operator--( int )
	   {

		    
		   for(int i=0;i<r;i=i+1)
			{
				for(int j=0;j<c;j=j+1)
					{
						f[i][j]--;
			     	}
		   }
		  return *this;


	   }
	    array1 operator+( array1 &obj)
	 {    
		  
		  for(int i=0;i<r;i=i+1)
			{
				for(int j=0;j<c;j=j+1)
					{
					f[i][j] = (f[i][j]+obj.f[i][j]);
			     	}
		   }
		  return *this;

	 }
		  array1 operator-( array1 &obj)
	 {    
		  
		  for(int i=0;i<r;i=i+1)
			{
				for(int j=0;j<c;j=j+1)
					{
					f[i][j] = (f[i][j]-obj.f[i][j]);
			     	}
		   }
		  return *this;

	 }
		  
		  array1 operator*( array1 &obj)
	 {    
		  
		  for(int i=0;i<r;i=i+1)
			{
				for(int j=0;j<c;j=j+1)
					{
					f[i][j] = (f[i][j]*obj.f[i][j]);
			     	}
		   }
		  return *this;

	 }
		  array1 operator/( array1 &obj)
	 {    
		  
		  for(int i=0;i<r;i=i+1)
			{
				for(int j=0;j<c;j=j+1)
					{
					f[i][j] = (f[i][j] / obj.f[i][j]);
			     	}
		   }
		  return *this;

	 }
		 array1()
		 {
		 }
		 ~ array1()
		 {   
			 for(int i=0;i<r;i=i+1)
		  { 
			delete [] f[i];
			f[i]=0;
		 }
			 delete [] f;
			 f=0;
		 }

		void  transpose(int v,int i,int j)
		 {

			 f[i][j]=v;
		 }
		int gettranspose( int i, int j)
		{  
			return f[j][i];

		}
}; 
int main()
{    
	int v,r1,c1,c2,r2;
    cout << "enter the row num for first matrix"<<endl;
	cin >> r1;
	cout << "enter the columb num for first matix"<<endl;
	cin >> c1;
	cout << "enter the row num for second matrix"<<endl;
	cin >> r2;
	cout << "enter the columb num for seciond matrix "<<endl;
	cin >> c2;

	array1 arr(r1,c1),arr1(r2,c2);
	// entrer values for the first matrix
	cout << "set values for the first matrix "<<endl;
	for(int i=0;i<r1;i=i+1)
	  {   
				 for(int j=0;j<c1;j=j+1)
			 {   
				 cout << "enter value"<<endl;
				 cin >> v;
				 arr.setvalue(v,i,j);
			}
	   }
	cout << "set valus for the second matrix"<<endl;
	            for(int i=0;i<r2;i=i+1)
	  {   
				 for(int j=0;j<c2;j=j+1)
			 {   
				 cout << "enter value"<<endl;
				 cin >> v;
				 arr1.setvalue(v,i,j);
			}
	  }  
	// assignment opertor call 
	arr1=arr;
	cout << "assignment take palce "<<endl;
	for(int i=0;i<r1;i=i+1)
	 {   
				 for(int j=0;j<c1;j=j+1)
			 {   
				 cout  << " "  <<  arr1.getvalue(i,j)<<endl;
		     }
	}

	cout << "comprism take place "<<endl;
	// comprism opertor call 
	if(arr>arr1)
		cout << "first is greater tahn other"<<endl;
		if(arr<arr1)
		cout << "first is less tahn other"<<endl;
		if(arr==arr1)
		cout << "first is equal to other"<<endl;
		if(arr <=arr1)
			cout << "first is less than equal to second"<<endl ;
		if(arr>=arr1)
			cout << "first is greater than equal to second "<<endl;
		if(arr != arr1)
			cout << "first is not  equal to second "<<endl;
		// prefix increment  opetor call 
		cout << "prefix incerement take place "<<endl;
	arr=++arr1;
	for(int i=0;i<r1;i=i+1)
	 {   
				 for(int j=0;j<c1;j=j+1)
			 {   
				 cout << "dispaly valiue " << " "  <<  arr.getvalue(i,j)<<endl;
		     }
	}
	// post fis increment  opetor call 
	cout << "postfix incremwent opertor call "<<endl;
	arr=arr1++;
	for(int i=0;i<r1;i=i+1)
	 {   
				 for(int j=0;j<c1;j=j+1)
			 {   
				 cout << "dispaly valiue " << " "  <<  arr.getvalue(i,j)<<endl;
		     }
	}
		// prefix decrement   opetor call 
	cout << " prefix decrement opertaor take palce "<<endl;
	arr= --arr1;
	for(int i=0;i<r1;i=i+1)
	 {   
				 for(int j=0;j<c1;j=j+1)
			 {   
				 cout << "dispaly valiue " << " "  <<  arr.getvalue(i,j)<<endl;
		     }
	}
	// post fis decrement   opetro call 
	cout << "postfix decrement opertion take place "<<endl;
	arr= arr1--;
	for(int i=0;i<r1;i=i+1)
	 {   
				 for(int j=0;j<c1;j=j+1)
			 {   
				 cout << "dispaly valiue " << " "  <<  arr.getvalue(i,j)<<endl;
		     }
	}
	// addition of two matrix
	cout << "addition of matrix take plae " <<endl;
	arr = arr+arr1;
	for(int i=0;i<r1;i=i+1)
	 {   
				 for(int j=0;j<c1;j=j+1)
			 {   
				 cout << "dispaly valiue " << " "  <<  arr.getvalue(i,j)<<endl;
		     }
	}
	// subtraction of matrix 
	cout << " subtarction of matrix take place "<<endl;
	arr = arr-arr1;
	for(int i=0;i<r1;i=i+1)
	 {   
				 for(int j=0;j<c1;j=j+1)
			 {   
				 cout << "dispaly valiue " << " "  <<  arr.getvalue(i,j)<<endl;
		     }
	}
	// multiplication of matrix 
	cout << "multpliction of matrix take place "<<endl;
	arr = arr*arr1;
	for(int i=0;i<r1;i=i+1)
	 {   
				 for(int j=0;j<c1;j=j+1)
			 {   
				 cout << "dispaly valiue " << " "  <<  arr.getvalue(i,j)<<endl;
		     }
	}// division of matrix 
	cout << ":division of matrix take plce " <<endl;
	arr = arr/arr1;
	for(int i=0;i<r1;i=i+1)
	 {   
				 for(int j=0;j<c1;j=j+1)
			 {   
				 cout << "dispaly valiue " << " "  <<  arr.getvalue(i,j)<<endl;
		     }
	}
	// transp0se of a matrix 
	int r3,c3;
   cout << " enyer teh row num of the transpose matrix "<<endl;
   cin >> r3;
   cout << "enter the colom num of transpose  matrix "<<endl;
   cin >> c3;
	array1 arr3(r3,c3);
	int a;
	for(int i=0;i<r3;i=i+1)
	 {   
				 for(int j=0;j<c3;j=j+1)
			 {    
				  cout << "enter value"<<endl;
				 cin >> a;
				  arr3.transpose(v,i,j);
		     }
	}
	for(int i=0;i<r3;i=i+1)
	 {   
				 for(int j=0;j<c3;j=j+1)
			 {   
				  cout  << arr3.gettranspose(i,j) << "  ";
		     }
	}    cout << endl;
 return 1;
}
          