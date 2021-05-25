# GearShop Intro
This is the Github Repository for the Gear Shop Web MVC that I created for my Red Badge Final Project for Eleven Fifty Academy. All work has been deployed to Azure, as well as pushed to this Github Repository. Overall, this project took roughly 2 1/2 weeks to complete, and I was responsible for all of the frontend and backend.

# GearShop Code
This project was titled GearShop, and the website is titled Peter's Outdoor Gear Emporium. The goal was relatively simple: create a website similar to the likes of REI where users can view outdoor gear for many different companies, buy whatever gear they want, and leave comments, replies, and reviews of different pieces of gear.

I created this MVC using n-tier architecture. There are four separate layers in the project. The data layer holds the specific data tables and databases that are used by the shop. I had a total of 6 different tables: Gear, Categories, Comments, Replies, Carts, and IndividualGearInCarts (this last data table is used exclusively by the cart to hold temporary instances of gear for individual users of the site).

The next layer is the models layer, where I created folders to hold all of the models for the different data talbes I was using. These models would be used to pass specific information back to the data tables in the data layer, and they would also make sure that only specific information was being shown to the viewer if I ever wanted to do that.

The third layer is the services layer. This is the layer that speaks between the WebMVC and the data tables themselves. All operations and changes to data were carried out in the services layer. If data was ever edited, created, deleted, or viewed, this is the layer that communicated with the data tables to get that done.

The final layer is the WebMVC layer. This is the frontend of the website, and includes the controllers and the views. These controllers interact with the views in the WebMVC layer, as well as the services in the services layer, to allow the user control over the data. The controllers pass information to the service layer, and they also take information from the service layer and display it to the user. The views in this layer allow frontend functionality, and make it easy for the user to see and understand what they are doing and what is going on.

