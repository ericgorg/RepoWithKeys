using Azure.Storage.Blobs;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();


string key = "DefaultEndpointsProtocol=https;AccountName=ericgignite2024;AccountKey=3wUoZzzxJZRul3oEg6nf4v8nVzRfvQC/sVtvpBloBDHdIAZQdAZWOkjH7A31ig2ud2PdK2GaPbU8+AStcxPIPQ==;EndpointSuffix=core.windows.net";
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


