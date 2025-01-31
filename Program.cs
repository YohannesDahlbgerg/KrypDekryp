using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!!!");

app.MapPost("/Kryptering", (KryptoRequest request) =>
{
    if (string.IsNullOrWhiteSpace(request.Text))
        return Results.BadRequest("Text får inte vara tom.");

    string encryptedText = CaesarEncrypt(request.Text, request.Key);
    return Results.Ok(new { EncryptedText = encryptedText });
});

app.MapGet("/Dekryptering", () => "");

app.Run();

// Metod för Caesar-chiffer
string CaesarEncrypt(string text, int key) => CaesarShift(text, key);

string CaesarShift(string text, int key)
{
    char[] result = new char[text.Length];
    key = key % 26; // Hantera nycklar större än alfabetet

    for (int i = 0; i < text.Length; i++)
    {
        char c = text[i];

        if (char.IsLetter(c))
        {
            char offset = char.IsUpper(c) ? 'A' : 'a';
            result[i] = (char)((((c - offset) + key + 26) % 26) + offset);
        }
        else
        {
            result[i] = c; // Behåll andra tecken oförändrade
        }
    }

    return new string(result);
}

// Requestmodell för API
public class KryptoRequest
{
    public string Text { get; set; }
    public int Key { get; set; }
}