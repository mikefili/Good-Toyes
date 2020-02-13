<h1 align="center">Good Toyes</h1>
<img src="/Assets/dog-2.jpg") >

<h2>Product</h2>

Good Toyes is your source for everything your good boy needs! All types of toys, treats, and enticements. Now offering discounts for spayed/neutered pets.

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


<h2>How To Get Around</h2>

<h3>Home Page</h2>
<img src="/Assets/ecom/home.PNG" >

<h3>Login Page</h2>
<img src="/Assets/ecom/login.PNG" >

<h3>Registration Page</h2>
<img src="/Assets/ecom/register.PNG" >

<h3>Admin Dashboard</h3>
<img src="/Assets/ecom/admin.PNG" >

<h3>Shopping Page</h2>
<img src="/Assets/ecom/shop1.PNG" >
<img src="/Assets/ecom/shop2.PNG" >

<h3>Product Landing Page</h2>
<img src="/Assets/ecom/product.PNG" >

<h3>Cart Page</h2>
<img src="/Assets/ecom/cart.PNG" >

<h3>Checkout page</h2>
<img src="/Assets/ecom/checkout.PNG" >

<h3>Receipt/Order Confirmation Page</h2>
<img src="/Assets/ecom/receipt.PNG" >

<h3>Personal Profile Page</h2>
<img src="/Assets/ecom/profile.PNG" >


<h3>Database Schema</h2>
<img src="/Assets/goodtoyes_db_schema.PNG" >

As users add items to their cart, the product information is passed on into the cart items model through a one-to-one relationship. Each user only has one cart at a time, resulting in a similar one-to-one relationship. Once a user has decided to purchase the items in their cart, the cart and cart item properties are passed with view models to become an order of order items for persistence purposes. This will allow a user to see their order history.


<h3>Vulnerability Report</h3>
We analyzed the vulnerabilities surrounding the deployment of an e-commerce platform like this, including SQL injection, access control, sensitive data exposure, and more. A full report with examples can be found <a href="/vulnerability-report.md">here</a>.


<h3>Contributors</h3>
Jason Few & Mike Filicetti
