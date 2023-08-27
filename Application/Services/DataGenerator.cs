﻿using Bogus;

namespace Services;

public class DataGenerator
{

    /// <summary>
    /// Метод генерации случайного пользователя
    /// </summary>
    /// <returns>Случайный объект типа User</returns>
    public static User GenerateUser() => new Faker<User>("ru")
        .RuleFor(user => user.UserName, user => user.Name.FirstName())
        .RuleFor(user => user.EmailAddress, user => user.Internet.Email())
        .RuleFor(user => user.Phone, user => user.Phone.PhoneNumberFormat())
        .RuleFor(user => user.DateOfBirth, user => user.Date.BetweenDateOnly(
        DateOnly.FromDateTime(DateTime.Now.AddYears(-80).Date),
        DateOnly.FromDateTime(DateTime.Now.AddYears(-18).Date)))
        .RuleFor(user => user.PasswordSalt, user => user.Hashids.Encode(Random.Shared.Next(100, 1000)))
        .RuleFor(user => user.PasswordHash, user => user.Hashids.Encode(Random.Shared.Next(100, 1000)))
        .RuleFor(user => user.RoleId, user => user.Random.Int(1, 3))
        .Generate();

    public static Article GenerateArticle() => new Faker<Article>("ru")
        .RuleFor(art => art.Title, art => art.Name.FullName())
        .RuleFor(art => art.Subtitle, art => art.Lorem.Word())
        .RuleFor(art => art.SectionId, art => art.Random.Int(1, 8))
        .RuleFor(art => art.Image, art => art.Image.LoremPixelUrl())
        .RuleFor(art => art.Text, art => art.Lorem.Text())
        .Generate();
}
