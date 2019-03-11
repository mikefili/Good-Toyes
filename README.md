<h1 align="center">Good Toyes</h1>
<img src="https://dev.azure.com/GoodToyes/e4e7016b-8089-4a55-9fa3-26c24f1bad71/_apis/git/repositories/ea4d2d35-b6aa-43f7-b387-39101dcd35b8/Items?path=%2FAssets%2Fdog-2.jpg&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=CheckoutPage&download=false&resolveLfs=true&%24format=octetStream&api-version=5.0-preview.1") >

<h2>Product</h2>

Good Toyes is your source for everything your good boy needs! All types of toys, treats, and enticements. Now offering discounts for spayed/neutered pets.


<h2>Deployed Link</h2>
https://goodtoyes.azurewebsites.net/


<h2>Claims</h2>

<h3>Full Name</h3>
By creating a single claim out of a user's first and last names, we can greet the user on each page with a personalized greeting.

<h3>Email</h3>
An email claim allows a user's information to pass from view to view seamlessly.

<h3>Date of Birth</h3>
Provides quick and easy age verification, should the need arise.

<h3>Spay or Neutered</h3>
We created a claim that allows a user to specify if their pet is spayed or neutered.


<h2>Policy</h2>
We are enforcing a Spay or Neuter policy.  If you have spayed or neutered your pet we are allowing users access to a very special page because they are responsible pet owners.


<h2>OAuth External Login Providers</h2>

Users can either register with an email address and your information, or allow a third party to do so for them. Press either the Login with Facebook or Login with Microsoft buttons from the Login Page to utilize these services.


<h2>System Design</h2>

<h3>Database Schema</h2>
<img src="https://dev.azure.com/GoodToyes/e4e7016b-8089-4a55-9fa3-26c24f1bad71/_apis/git/repositories/ea4d2d35-b6aa-43f7-b387-39101dcd35b8/Items?path=%2FAssets%2Fgoodtoyes_db_schema.PNG&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=README&download=false&resolveLfs=true&%24format=octetStream&api-version=5.0-preview.1" >

As users add items to their cart, the product information is passed on into the cart items model through a one-to-one relationship. Each user only has one cart at a time, resulting in a similar one-to-one relationship. Once a user has decided to purchase the items in their cart, the cart and cart item properties are passed with view models to become an order of order items for persistence purposes. This will allow a user to see their order history.

<h3>Contributors</h3>
Jason Few & Mike Filicetti
