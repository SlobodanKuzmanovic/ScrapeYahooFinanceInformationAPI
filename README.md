# Yahoo Finance API

Scrape Yahoo Finance Information API

## Getting Started

Before starting You need to have installed MS SQL server.

### Prerequisites

Import data into your local MS SQL server. Find files in the root file of the project (DB.zip (inside You can find sql script and bak file of the database, use what you prefer)).

In the root file of the project you can find appsettings.json file connection string by the name "YahooDBConStr" so app can connect to your database.
```json
"ConnectionStrings": {
  "YahooDBConStr": "Data Source=Your_Server_Name;Initial Catalog=YahooFinance;User ID=Your_User;Password=Your_Pass"
}
```

After running the app Swagger should be up and running and You can call a method to retrive data from Yahoo finance API.
