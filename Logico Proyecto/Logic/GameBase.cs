namespace Logic;

public class GameBase
{


       public Players player1;
       public Players player2;
       public static GameBase? Game;
       public GameBase()
       {
              Game=this;
              Boards board1 = new Boards();
              Boards board2 = new Boards();

              BossCard  bossCard = new BossCard("CJ","Rockstar",30,new BossEffect(),player1!);
              BossCard bossCard1=new BossCard("Joel Miller","Naughty Dog",30,new BossEffect2(),player2!);
              board1.SetCard(bossCard,Boards.Rows.Heroe);
              board2.SetCard(bossCard1,Boards.Rows.Heroe);
              
              UnitsCard card1= new UnitsCard("Michael","Rockstar",15,UnitsCard.AtackType.RS,UnitsCard.UnitType.Silver,new DeleteMorePowerCard(),player1!);
              UnitsCard card2= new UnitsCard("Franklin","Rockstar",12,UnitsCard.AtackType.MS,UnitsCard.UnitType.Silver,new DeleteLessPowerCard(),player1!);
              UnitsCard card3= new UnitsCard("PD","Rockstar",10,UnitsCard.AtackType.M,UnitsCard.UnitType.Silver,new DeleteCardInGame(),player1!);
              UnitsCard card6=new UnitsCard("Trevor","Rockstar",20,UnitsCard.AtackType.MRS,UnitsCard.UnitType.Gold,new CleanRow(),player1!);
              WeatherCard card4= new WeatherCard("Mujerzuela"," ",new SetWeather2(),player1!);
              WeatherCard card5= new WeatherCard("Dream Team"," ",new SetWeather4(),player1!);
              UnitsCard card7=new UnitsCard("Bully","Rockstar",10, UnitsCard.AtackType.MR, UnitsCard.UnitType.Silver,new Steal(),player1!);
              Lure card8=new Lure("Homeless","Rockstar", new SetLure(),player1!);
              Clearance card9=new Clearance("Niko Bellic","Rockstar", new DeleteWeather(),player1!);
              Increase card10=new Increase("Big Boss","Rockstar", new IncreaseRow2(),player1!);
              UnitsCard card11=new UnitsCard("GrandPa","Rockstar",13, UnitsCard.AtackType.R, UnitsCard.UnitType.Silver, new DeleteMorePowerCard(),player1!);
              UnitsCard card12=new UnitsCard("Billy","Rockstar",16, UnitsCard.AtackType.MRS, UnitsCard.UnitType.Gold,new DeleteLessPowerCard(),player1!);
              UnitsCard card13=new UnitsCard("Capo","Rockstar",14, UnitsCard.AtackType.S, UnitsCard.UnitType.Silver,new DeleteCardInGame(),player1!);
              UnitsCard card14=new UnitsCard("Thomas","Rockstar",12, UnitsCard.AtackType.R, UnitsCard.UnitType.Silver, new Steal(),player1!);
              UnitsCard card15=new UnitsCard("BigPoppa","Rockstar",15, UnitsCard.AtackType.MS, UnitsCard.UnitType.Silver,new CleanRow(),player1!);
              Increase card16=new Increase("Squad","Rockstar", new IncreaseRow4(),player1!);
              UnitsCard card17=new UnitsCard("Pollete","Rockstar",10, UnitsCard.AtackType.M, UnitsCard.UnitType.Silver,new NoEffect(),player1!);
              UnitsCard card18=new UnitsCard("Gangster","Rockstar",17, UnitsCard.AtackType.M, UnitsCard.UnitType.Silver,new PlusOne(),player1!);
              UnitsCard card19=new UnitsCard("Tony","Rockstar",12, UnitsCard.AtackType.RS, UnitsCard.UnitType.Silver, new NoEffect(),player1!);
              
              UnitsCard card33=new UnitsCard("Hammers","Rockstar",12, UnitsCard.AtackType.MS, UnitsCard.UnitType.Silver,new SetWeather(),player1!);
              UnitsCard card34=new UnitsCard("Toni Cipriani","Rockstar",13, UnitsCard.AtackType.RS, UnitsCard.UnitType.Silver,new SetIncrease(),player1!);
              UnitsCard card35=new UnitsCard("RealG","Rockstar",14, UnitsCard.AtackType.S, UnitsCard.UnitType.Silver,new IncreasePower(),player1!);
              UnitsCard card36=new UnitsCard("Butty","Rockstar",11, UnitsCard.AtackType.M, UnitsCard.UnitType.Silver,new Average(),player1!);




              
              
              
              
              UnitsCard card20=new UnitsCard("Ellie","Naughty Dog",20, UnitsCard.AtackType.MRS, UnitsCard.UnitType.Gold,new CleanRow(),player2! );
              UnitsCard card21=new UnitsCard("Young Ellie","Naughty Dog",15, UnitsCard.AtackType.M, UnitsCard.UnitType.Silver, new DeleteMorePowerCard(),player2!);
              UnitsCard card22=new UnitsCard("Drake","Naughty Dog",16, UnitsCard.AtackType.R, UnitsCard.UnitType.Silver,new DeleteLessPowerCard(),player2! );
              UnitsCard card23=new UnitsCard("Roman","Naughty Dog",12, UnitsCard.AtackType.S, UnitsCard.UnitType.Silver, new Steal(),player2! );
              UnitsCard card24=new UnitsCard("Chloe","Naughty Dog",14, UnitsCard.AtackType.MS, UnitsCard.UnitType.Silver, new DeleteCardInGame(),player2!);
              UnitsCard card25=new UnitsCard("Steve","Naughty Dog",11, UnitsCard.AtackType.MR, UnitsCard.UnitType.Silver,new PlusOne(),player2!);
              UnitsCard card26=new UnitsCard("Fox","Naughty Dog",13, UnitsCard.AtackType.RS, UnitsCard.UnitType.Silver, new DeleteLessPowerCard(),player2!);
              UnitsCard card27=new UnitsCard("Blonde","Naughty Dog",16, UnitsCard.AtackType.MR, UnitsCard.UnitType.Silver, new Steal(),player2!);
              WeatherCard card28=new WeatherCard("Stop","Naughty Dog",new SetWeather2(),player2!);
              WeatherCard card29=new WeatherCard("Cynder","Naughty Dog",new SetWeather4(),player2!);
              Increase card30=new Increase("Great Squad","Naughty Dog", new IncreaseRow2(),player2!);
              Increase card31=new Increase("Jimmy Neutron", "Naughty Dog", new IncreaseRow4(),player2!);
              Clearance card32=new Clearance("Brave Drake","Naughty Dog",new DeleteWeather(),player2!);

              UnitsCard card37=new UnitsCard("Infectados","Naughty Dog",12, UnitsCard.AtackType.MR, UnitsCard.UnitType.Silver,new SetWeather(),player2!);
              UnitsCard card38=new UnitsCard("Riley","Naughty Dog",11, UnitsCard.AtackType.RS, UnitsCard.UnitType.Silver,new SetIncrease(),player2!);
              UnitsCard card39=new UnitsCard("GunMan","Naughty Dog",10, UnitsCard.AtackType.R, UnitsCard.UnitType.Silver,new IncreasePower(),player2!);
              UnitsCard card40=new UnitsCard("Brave Ellie","Naughty Dog",18, UnitsCard.AtackType.MRS, UnitsCard.UnitType.Gold,new Average(),player2!);



            UnitsCard card41=new UnitsCard("Michael","Rockstar",15,UnitsCard.AtackType.RS,UnitsCard.UnitType.Silver,new DeleteMorePowerCard(),player1!);
            UnitsCard card42=new UnitsCard("Franklin","Rockstar",12,UnitsCard.AtackType.MS,UnitsCard.UnitType.Silver,new DeleteLessPowerCard(),player1!);
           Clearance card43= new Clearance("Niko Bellic","Rockstar", new DeleteWeather(),player1!);
            Clearance card44= new Clearance("Niko Bellic","Rockstar", new DeleteWeather(),player1!);
            UnitsCard card45= new UnitsCard("Capo","Rockstar",14, UnitsCard.AtackType.S, UnitsCard.UnitType.Silver,new DeleteCardInGame(),player1!);
           Increase card46= new Increase("Squad","Rockstar", new IncreaseRow4(),player1!);
            UnitsCard card47=new UnitsCard("RealG","Rockstar",14, UnitsCard.AtackType.S, UnitsCard.UnitType.Silver,new IncreasePower(),player1!);
       UnitsCard card48=new UnitsCard("RealG","Rockstar",14, UnitsCard.AtackType.S, UnitsCard.UnitType.Silver,new IncreasePower(),player1!);

               
              
            UnitsCard card49=new UnitsCard("Young Ellie","Naughty Dog",15, UnitsCard.AtackType.M, UnitsCard.UnitType.Silver, new DeleteMorePowerCard(),player2!);
            UnitsCard card50=new UnitsCard("Drake","Naughty Dog",16, UnitsCard.AtackType.R, UnitsCard.UnitType.Silver,new DeleteLessPowerCard() ,player2!);
           UnitsCard card51=new UnitsCard("Drake","Naughty Dog",16, UnitsCard.AtackType.R, UnitsCard.UnitType.Silver,new DeleteLessPowerCard(),player2! );
            UnitsCard card52=new UnitsCard("Roman","Naughty Dog",12, UnitsCard.AtackType.S, UnitsCard.UnitType.Silver, new Steal() ,player2!);
           UnitsCard card53= new UnitsCard("Roman","Naughty Dog",12, UnitsCard.AtackType.S, UnitsCard.UnitType.Silver, new Steal() ,player2!);
            UnitsCard card54= new UnitsCard("Chloe","Naughty Dog",14, UnitsCard.AtackType.MS, UnitsCard.UnitType.Silver, new DeleteCardInGame(),player2!);
            UnitsCard card55= new UnitsCard("Steve","Naughty Dog",11, UnitsCard.AtackType.MR, UnitsCard.UnitType.Silver,new PlusOne(),player2!);
           UnitsCard card56= new UnitsCard("Fox","Naughty Dog",13, UnitsCard.AtackType.RS, UnitsCard.UnitType.Silver, new DeleteLessPowerCard(),player2!);
            UnitsCard card57= new UnitsCard("Blonde","Naughty Dog",16, UnitsCard.AtackType.MR, UnitsCard.UnitType.Silver, new Steal(),player2!);
             Increase card58= new Increase("Great Squad","Naughty Dog", new IncreaseRow2(),player2!);
            Clearance card59= new Clearance("Brave Drake","Naughty Dog",new DeleteWeather(),player2!);
           Clearance card60= new Clearance("Brave Drake","Naughty Dog",new DeleteWeather(),player2!);
            UnitsCard card61= new UnitsCard("GunMan","Naughty Dog",10, UnitsCard.AtackType.R, UnitsCard.UnitType.Silver,new IncreasePower(),player2!);
            UnitsCard card62= new UnitsCard("GunMan","Naughty Dog",10, UnitsCard.AtackType.R, UnitsCard.UnitType.Silver,new IncreasePower(),player2!);













                
              

              Decks deck1 = new Decks(card1,card2,card3,card4,card5,card6, card7, card8,card9,card10,card11,card12,
              card13,card14,card15,card16,card17,card18,card19,  card33,card34,card35,card36,card41,card42,card43,
              card44,card45,card46,card47,card48  );
              
              Decks deck2 = new Decks(card20,card21,card22,card23,card24,card25,card26,card27,card28,card29,card30,card31,card32,
                      card37,card38,card39,card40,card49,card50,card51,card52,card53,card54,card55,card56,card57,card58,card59,card60,
                      card61,card62 );
          
              
              player1 = new Players(deck1, board1);
              player2 = new Players(deck2, board2);




       }

       public static Players GetPlayers(int player)
       {
          return (player==1)? Game!.player1:Game!.player2;
       }
} 