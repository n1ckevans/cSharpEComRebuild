# Nick's Skate Shop - eCommerce
# http://54.193.7.242/

Nick's Skate Shop is a full-stack E-Commerce web application, built using C# with ASP.NET Core framework. 
Nick's Skate Shop first welcomes users to a landing page, where current promotions are displayed. 
Items can be added to a shopping cart, which is stored in session until the user is ready to checkout. 
Once a user is ready to checkout, an order summary page is displayed After successful purchase, users are redirected to an order confirmation page. 
Admins can Create, Update or Remove items, which will update the items available for purchase. 
Each item for sale is a unique object stored into a MySQL database. 
Nick's Skate Shop is deployed using AWS EC2 on an Ubuntu server with NGINX and Supervisor.

## Getting Started

The landing page lists current promotions in a carousel. By clicking anywhere inside the image, users can see all available products for sale.
Featured items are also listed on the landing page, and can be clicked on to view addtional information or added to the users cart.

### Products

Users can view all of the available products, or can view individual categories of items. Each item can be viewed in more detail by simply clicking on the product.

### Checking Out

Once all items have been added to the shopping cart, users can checkout. Before checkout, an order summary of all the items selected will appear.
This summary contains the quantity, image, price and name of each item in the shopping cart. Once the summary has been confirmed, users will submit their order.

### Order Confirmation

After successfully checking out, users will be shown an oder confirmation which lists a detailed summary of all items purchased, as well as a order number.
