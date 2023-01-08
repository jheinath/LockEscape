﻿using System.Globalization;
using System.Text;
using Domain.EscapeGames.Aggregate;
using Domain.EscapeGames.ValueObjects;
using HashidsNet;

namespace LockEscape.Services.EncodingToQueryParameters;

public class GenerateQueryParametersService : IGenerateQueryParametersService
{
    public string GenerateQueryParameters(EscapeGame escapeGame)
    {
        var queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);

        
        queryString.Add(nameof(CreatorPassword), escapeGame.CreatorPassword.Value);
        queryString.Add(nameof(CultureInfo), escapeGame.CultureInfo.Name);

        for (var i = 0; i < escapeGame.Riddles.Count(); i++)
        {
            queryString.Add(nameof(RiddleSolution) + i, escapeGame.Riddles.ElementAt(i).RiddleSolution.Value);
            queryString.Add(nameof(IsSolved) + i, escapeGame.Riddles.ElementAt(i).IsSolved.Value.ToString());
        }
        
        for (var i = 0; i < escapeGame.Riddles.Count(); i++)
        {
            queryString.Add(nameof(GroupNumber) + i, escapeGame.GameSolutionForGroups.ElementAt(i).GroupNumber.Value.ToString());
            queryString.Add(nameof(GameSolution) + i, escapeGame.GameSolutionForGroups.ElementAt(i).GameSolution.Value);
        }

        var bytes = Encoding.Default.GetBytes(queryString.ToString()!);
        var hexString = BitConverter.ToString(bytes);
        hexString = hexString.Replace("-", "");

        var hashids = new Hashids(HashIdConfiguration.Salt);
        return hashids.EncodeHex(hexString);
    }
}