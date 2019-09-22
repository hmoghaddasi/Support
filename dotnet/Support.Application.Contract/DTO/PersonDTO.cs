
using System;

namespace Support.Application.Contract.DTO
{
	public class PersonDTO
	{	    
       	   public int PersonId {get;set;}
	   	   public string FirstName {get;set;}
	   	   public string LastName {get;set;}
	   	   public string UserName {get;set;}
	   	   public string Password {get;set;}
	   	   public string Email {get;set;}
	   	   public string Mobile {get;set;}
	   	   public string CompanyName {get;set;}
	   	   public bool Gender {get;set;}
	   	   public int TypeId {get;set;}
	   	   public int StatusId {get;set;}
	   	   public DateTime CreateDate {get;set;}
           public string FullName { get; set; }
           public string GenderText { get; set; }
           public string LoginName { get; set; }
           public string Status { get; set; }
    }
}