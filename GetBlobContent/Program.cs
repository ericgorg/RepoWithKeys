using Azure.Storage.Blobs;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();


string key = "DefaultEndpointsProtocol=https;AccountName=ericgignite2024;AccountKey=VEg1ZsR613kD8sgnjtc5L5RqIue0rXjut8wLXOUip70f3OZVckPmPHDP1wmpBv4RicGxWfy1MvNm+AStQWQMVg==;EndpointSuffix=core.windows.net";
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


