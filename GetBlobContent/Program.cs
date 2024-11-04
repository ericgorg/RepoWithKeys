

using Azure.Storage.Blobs;
using System.Text;
using System;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();


string key = "DefaultEndpointsProtocol=https;AccountName=ericgignite2024;AccountKey=VEg1ZsR613kD8sgnjtc5L5RqIue0rXjut8wLXOUip70f3OZVckPmPHDP1wmpBv4RicGxWfy1MvNm+AStQWQMVg==;EndpointSuffix=core.windows.net";
string containerName = "container1";


app.MapGet("/writeBlob", async () =>
    {
        try
        {
            //create storage account client
            var blobServiceClient = new BlobServiceClient(key);

            //create container client
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            //generate content
            string message = DateTime.Now.ToString(); 
            byte[] byteArray = Encoding.ASCII.GetBytes(message);

            //generate blobname
            string blobName = Guid.NewGuid().ToString();

            //upload blob     
            using (MemoryStream stream = new MemoryStream(byteArray))
            {
                await containerClient.UploadBlobAsync(blobName, stream);
            }

            return blobName;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }

    });


app.Run();


