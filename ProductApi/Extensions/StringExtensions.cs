using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace ProductApi.Extensions;

/// <summary>
/// Méthodes d'extension pour les chaînes de caractères
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Génère un slug à partir d'une chaîne de caractères.
    /// Convertit en minuscules, remplace les espaces par des tirets,
    /// supprime les caractères non alphanumériques (sauf tirets).
    /// </summary>
    /// <param name="input">La chaîne d'entrée (ex: nom du produit).</param>
    /// <returns>Le slug généré.</returns>
    public static string ToSlug(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return string.Empty;
        }

        // Convertir en minuscules
        string slug = input.ToLowerInvariant();

        // Remplacer les caractères accentués par leurs équivalents non accentués
        slug = RemoveDiacritics(slug);

        // Remplacer les espaces par des tirets
        slug = Regex.Replace(slug, @"\s+", "-");

        // Supprimer les caractères non alphanumériques (sauf tirets)
        slug = Regex.Replace(slug, @"[^a-z0-9\-]", "");

        // Supprimer les tirets consécutifs
        slug = Regex.Replace(slug, @"\-\-+", "-");

        // Supprimer les tirets au début et à la fin
        slug = slug.Trim('-');

        return slug;
    }

    /// <summary>
    /// Supprime les caractères diacritiques (accents) d'une chaîne.
    /// </summary>
    private static string RemoveDiacritics(string text)
    {
        var normalizedString = text.Normalize(NormalizationForm.FormD);
        var stringBuilder = new StringBuilder();

        foreach (var c in normalizedString)
        {
            var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark)
            {
                stringBuilder.Append(c);
            }
        }

        return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
    }
}