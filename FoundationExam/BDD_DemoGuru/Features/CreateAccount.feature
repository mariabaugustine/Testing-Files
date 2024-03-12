Feature: CreateAccount

New user can Create Account
Background:Given user will be on the home page 

@E2E_Create_Account

Scenario Outline:Registration for New User
	When User clicks on the registration link
	Then Create account page is loaded with url contains register
	When user types'<FirstName>','<LastName>','<Phone>','<Email>','<City>','<State>','<Postalcode>','<Address>','<Username>','<Password>','<Confirmpassword>'
	When User clicks on submit button
	Then User navigate to new page with url conains register_sucess
	 

	Examples: 
	| FirstName | LastName | Phone      | Email         | City      | State  | Postalcode | Address | Username | Password | Confirmpassword |
	| Aleena    | Ravi     | 9876543210 | abc@gmail.com | Payyannur | Kerala | 671532     | xdrft   | user     | 54321    | 54321           |

