Database Tables:

User Table:
	UserID (Primary Key)
	Password (Hashed and Salted)
	Email
	Phonenumber

Account Table:
	AccountID (Primary Key)
	UserID (Foreign Key referencing User.UserID)
	AccountNumber (Unique)
	Balance

Transaction Table:
	TransactionID (Primary Key)
	SenderAccountID (Foreign Key referencing Account.AccountID)
	ReceiverAccountID (Foreign Key referencing Account.AccountID)
	Amount
	Timestamp

ATM Table:
	ATMID (Primary Key)
	Location
	CashBalance


Microservices: 
	1. apigateway.service

	2. atm.service
		/check-balance
		/withdraw
		/deposit
		/transfer

	3. accounts.service
		/create
		/withdraw
		/deposit
		/transfer

	4. users.service
		/register
		/login



-------------------------

1. ATM Service
2. User Service
3. Ocelot API GW

-----------------------

Documentation 
- Infra Architecture
- Microservices 

Swagger Files

Source Code  

Customer Journey

-----------------------


curl.exe -X 'GET' 'http://localhost:65116/api/account'  -H 'accept: */*'