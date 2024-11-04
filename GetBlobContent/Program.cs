

using Azure.Storage.Blobs;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();


string key = "DefaultEndpointsProtocol=https;AccountName=ericgignite2024;AccountKey=TOREMOVEx900cp99f+oxKCi6oc7qh7HTvHy2e8eFdIb7Ovyj3V0Tz7Tt9PmkGNKAX5qNQLQ8GLTRZFM88JYv+AStkFkYlQ==;EndpointSuffix=core.windows.net";
string containerName = "container1";
string blobName = "Ignite2024.txt";


app.MapGet("/readBlobContent", async () =>
    {
        try
        {
            //create storage account client
            var blobServiceClient = new BlobServiceClient(key);

            //create container client
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            //create blob client
            var blobClient = containerClient.GetBlobClient(blobName);

            //download blob content
            var response = await blobClient.DownloadAsync();

            //read content
            var content = await new StreamReader(response.Value.Content).ReadToEndAsync();
            return content;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }

    });


app.Run();


