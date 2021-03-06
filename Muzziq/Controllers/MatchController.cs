﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Muzziq.Data;
using Muzziq.Models.Entities;
using Muzziq.Services;

namespace Muzziq.Controllers
{
    public class MatchController : Controller
    {

        private readonly MatchService matchService;
        private readonly ApplicationDbContext _context;
        public MatchController(ApplicationDbContext context)
        {
            _context = context;
            matchService = new MatchService(_context);
        }

        public IActionResult MatchView()
        {
            // TODO dużo rzeczy

            return View();
        }

        // TODO przekazanie w parametrze id meczu
        public IActionResult StartMatch()
        {
            // TODO przechwycenie, jaki mecz jest tworzony
            //Match match = matchService.CreateMatch(1, null, 2);
            matchService.StartMatch(1);
            // utworzenie meczu

            // rozgrywka

            Match match = prepareTestData();
            ViewData["Match"] = match;

            return View("MatchView");
        }

        // nie wiem czy ten punkt wejscia będzie potrzebny docelowo
        // mecz się kończy z ostatnim pytaniem i to wystarczy chyba
        public IActionResult EndMatch()
        {
            //matchService.EndMatch(_context.Matches.Find(1));
            // TODO zapisanie rozgrywki

            // TODO zwrócenie listy wyników

            Match match = prepareTestData();
            ViewData["Match"] = match;

            return View("MatchSummaryView");
        }

        private Match prepareTestData()
        {
            Match sampleMatch = new Match();
            sampleMatch.RoomId = 5;

            List<Result> results = new List<Result>();
            Player player1 = new Player(null, "jolka");
            Player player2 = new Player(null, "jolka,");
            Player player3 = new Player(null, "pamietasz");

            Result res1 = new Result();
            Result res2 = new Result();
            Result res3 = new Result();

            res1.Player = player1;
            res1.Points = 500;
            res2.Player = player2;
            res2.Points = 444;
            res3.Player = player3;
            res3.Points = 450;

            results.Add(res1);
            results.Add(res2);
            results.Add(res3);

            sampleMatch.Results = results;

            return sampleMatch;
        }
    }
}