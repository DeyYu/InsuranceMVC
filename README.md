# InsuranceMVC
Yoobee College Final Project READEME

Description:

a simple MVC Application for an insurance company

#Front End
* Contains multiple views written in cshtml and styled with css.
* Navigation bar contains company logo and routes to go to different parts on the site, which includes login, registration, home, about, services.
* Footer has a facebook link to like on a facebook page.
* Photo carousel and photo gallery was a require which has been added and has responsiveness to 480px width.

#Back End
* SQL server database that is linked to the front end with the Entity framework.
* Users can login and registry which enters the information into the database.
* Admins exist and are also granted more permissions.

Tables Include:
1. Cars (Contains CardId, Model, Rego, Value and Client Id)
2. Claims (Claim Id, Nature, Location, Date, Client Id, LicensePlate)
3. Clients (First name, Last name, Username, Password)
4. Contact (First name, Last name, Phone No, Email, Message)
5. Motorbike (MotorId, ModeOfUse, Rego, Value, Client Id)

Controller logics:

Admin
* Admins have their own homepage.
* Admin can read all contact messages sent from users.
* Admins can view all registered users.
* Admins can search a client by their Id, which also does not allow an null input.

Home
* Allows any user to submit a contact form into the database with their details and message.

User
* Users can register to the website and encrypts their password.
* Users can login with their username and password and will be sent to either the user's homepage or the admin page.
* Homepage automatically displays some of the users details.
* Users can edit their own details.
* Users can register a Vehicle to their account.
* Users can register a claim to their account.

