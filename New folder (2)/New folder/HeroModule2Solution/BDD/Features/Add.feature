Feature: Add



@E2E_add_new_use
 Scenario Outline: Add Users
	Given User will be on the home page
	When  User login using valid '<username>' and '<password>'
	Then  Next page is loaded with url containing contactlist
	When  User clich on AddnewContact button
	Then  The resulting page is loaded with url containing addcontact
	When  User fill the fields of '<firstname>','<lastname>','<dob>','<city>','<postalcode>','<address1>','<address2>','<phone>','<country>','<state>','<email>'
	And   User will click on the submit button
	Then  Next page is loaded with url containing contactlist

	Examples: 
	| username      | password | firstname | lastname | dob        | city       | postalcode | address1 | phone      | country | state  | email          | address2 |
	| rty@gmail.com | 1234567  | maya      | bin      | 1999-03-30 | trivandrum | 671532     | afdfds   | 9876543210 | india   | kerala | axcs@gmail.com | dfff     |


