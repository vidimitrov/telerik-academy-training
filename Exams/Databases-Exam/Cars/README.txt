For the connection string I use . if you use ./SQLEXPRESS please change it in the App.Config

Also if the db creation is very slow - stop the execution and work with the created record. You don't have to wait them all.

If you want to faster see the search and export to xml functions - comment the ImportJSONToDb method in the Main()

Thanks ;)