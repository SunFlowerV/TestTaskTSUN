using System.Text.Json;
using System.Net.Http.Json;
using System.Text.Json.Nodes;
using TestTaskTSUN;

using HttpClient client = new()
{
	BaseAddress = new Uri("https://pres.tsrealty.ru")
};


JsonNode root = await client.GetFromJsonAsync<JsonNode>("/testing.php");
JsonNode result = root!["result"]!;
JsonObject fildsObject = result!["fields"]!.AsObject();
using var stream = new MemoryStream();
using var writer = new Utf8JsonWriter(stream);
fildsObject.WriteTo(writer);
writer.Flush();
Dictionary<string, Field> fieldsDictionary = JsonSerializer.Deserialize<Dictionary<string, Field>>(stream.ToArray());
List<Field> fields = fieldsDictionary.Values.ToList();
List<Field> enumerationFields = fields.Where(x => x.type == "enumeration").ToList();
foreach (var enumerationField in enumerationFields)
{
	Guid uniqeName = Guid.NewGuid();
	Console.WriteLine($"Поле: {uniqeName}, имеет название: {enumerationField.upperName} и является полем типа enumeration");
	await SaveInDB(uniqeName);
}

async Task<string> SaveInDB(Guid uniqeName)
{
	Console.WriteLine($"Поле {uniqeName} добавлено в базу данных");
	return "OK";
}

