# chat-and-posts-feed-test
ASP.Net Core 6 chat app using SignalR Library and Post Upload test with multipart form type image vs base64 image. The compression of image size to 50% is also included in base64 type image upload.

* To Run the program, run the scripts.sql first in your SSMS

- In Visual Studio, right click on the solution in Solution Explorer and "Build Solution" to install necessary Libraries and Nuget Packages for this project.
- Running startup is configured to start both ChatAPI and ChatTestWeb. So, no further configuration is needed.
- Check out user table in database for providing credentials for the first login
- The path for chat app is "/chat/chatview"
- The path for post and comment feed is "/post/postview"
