namespace Logic;

public class GameBase
{


       public Players player1;
       public Players player2;
       public GameBase()
       {

              Boards board1 = new Boards();
              Boards board2 = new Boards();

              BossCard  bossCard = new BossCard("CJ","Rockstar",30,new BossEffect());
              BossCard bossCard1=new BossCard("Joel Miller","Naughty Dog",30,new BossEffect2());
              board1.SetCard(bossCard,Boards.Rows.Heroe);
              board2.SetCard(bossCard1,Boards.Rows.Heroe);
              
              UnitsCard card1= new UnitsCard("Michael","Rockstar",15,UnitsCard.AtackType.RS,UnitsCard.UnitType.Silver,new DeleteMorePowerCard());
              UnitsCard card2= new UnitsCard("Franklin","Rockstar",12,UnitsCard.AtackType.MS,UnitsCard.UnitType.Silver,new DeleteLessPowerCard());
              UnitsCard card3= new UnitsCard("PD","Rockstar",10,UnitsCard.AtackType.M,UnitsCard.UnitType.Silver,new DeleteCardInGame());
              UnitsCard card6=new UnitsCard("Trevor","Rockstar",20,UnitsCard.AtackType.MRS,UnitsCard.UnitType.Gold,new CleanRow());
              WeatherCard card4= new WeatherCard("Mujerzuela"," ",new SetWeather2());
              WeatherCard card5= new WeatherCard("Dream Team"," ",new SetWeather4());
              UnitsCard card7=new UnitsCard("Bully","Rockstar",10, UnitsCard.AtackType.MR, UnitsCard.UnitType.Silver,new Steal());
              Lure card8=new Lure("Homeless","Rockstar", new SetLure());
              Clearance card9=new Clearance("Niko Bellic","Rockstar", new DeleteWeather());
              Increase card10=new Increase("Big Boss","Rockstar", new IncreaseRow2());
              UnitsCard card11=new UnitsCard("GrandPa","Rockstar",13, UnitsCard.AtackType.R, UnitsCard.UnitType.Silver, new DeleteMorePowerCard());
              UnitsCard card12=new UnitsCard("Billy","Rockstar",16, UnitsCard.AtackType.MRS, UnitsCard.UnitType.Gold,new DeleteLessPowerCard());
              UnitsCard card13=new UnitsCard("Capo","Rockstar",14, UnitsCard.AtackType.S, UnitsCard.UnitType.Silver,new DeleteCardInGame());
              UnitsCard card14=new UnitsCard("Thomas","Rockstar",12, UnitsCard.AtackType.R, UnitsCard.UnitType.Silver, new Steal());
              UnitsCard card15=new UnitsCard("BigPoppa","Rockstar",15, UnitsCard.AtackType.MS, UnitsCard.UnitType.Silver,new CleanRow());
              Increase card16=new Increase("Squad","Rockstar", new IncreaseRow4());
              UnitsCard card17=new UnitsCard("Pollete","Rockstar",10, UnitsCard.AtackType.M, UnitsCard.UnitType.Silver,new NoEffect());
              UnitsCard card18=new UnitsCard("Gangster","Rockstar",17, UnitsCard.AtackType.M, UnitsCard.UnitType.Silver,new PlusOne());
              UnitsCard card19=new UnitsCard("Tony","Rockstar",12, UnitsCard.AtackType.RS, UnitsCard.UnitType.Silver, new NoEffect());
              
              UnitsCard card33=new UnitsCard("Hammers","Rockstar",12, UnitsCard.AtackType.MS, UnitsCard.UnitType.Silver,new SetWeather());
              UnitsCard card34=new UnitsCard("Toni Cipriani","Rockstar",13, UnitsCard.AtackType.RS, UnitsCard.UnitType.Silver,new SetIncrease());
              UnitsCard card35=new UnitsCard("RealG","Rockstar",14, UnitsCard.AtackType.S, UnitsCard.UnitType.Silver,new IncreasePower());
              UnitsCard card36=new UnitsCard("Butty","Rockstar",11, UnitsCard.AtackType.M, UnitsCard.UnitType.Silver,new Average());




              
              
              
              
              UnitsCard card20=new UnitsCard("Ellie","Naughty Dog",20, UnitsCard.AtackType.MRS, UnitsCard.UnitType.Gold,new CleanRow() );
              UnitsCard card21=new UnitsCard("Young Ellie","Naughty Dog",15, UnitsCard.AtackType.M, UnitsCard.UnitType.Silver, new DeleteMorePowerCard());
              UnitsCard card22=new UnitsCard("Drake","Naughty Dog",16, UnitsCard.AtackType.R, UnitsCard.UnitType.Silver,new DeleteLessPowerCard() );
              UnitsCard card23=new UnitsCard("Roman","Naughty Dog",12, UnitsCard.AtackType.S, UnitsCard.UnitType.Silver, new Steal() );
              UnitsCard card24=new UnitsCard("Chloe","Naughty Dog",14, UnitsCard.AtackType.MS, UnitsCard.UnitType.Silver, new DeleteCardInGame());
              UnitsCard card25=new UnitsCard("Steve","Naughty Dog",11, UnitsCard.AtackType.MR, UnitsCard.UnitType.Silver,new PlusOne());
              UnitsCard card26=new UnitsCard("Fox","Naughty Dog",13, UnitsCard.AtackType.RS, UnitsCard.UnitType.Silver, new DeleteLessPowerCard());
              UnitsCard card27=new UnitsCard("Blonde","Naughty Dog",16, UnitsCard.AtackType.MR, UnitsCard.UnitType.Silver, new Steal());
              WeatherCard card28=new WeatherCard("Stop","Naughty Dog",new SetWeather2());
              WeatherCard card29=new WeatherCard("Cynder","Naughty Dog",new SetWeather4());
              Increase card30=new Increase("Great Squad","Naughty Dog", new IncreaseRow2());
              Increase card31=new Increase("Jimmy Neutron", "Naughty Dog", new IncreaseRow4());
              Clearance card32=new Clearance("Brave Drake","Naughty Dog",new DeleteWeather());

              UnitsCard card37=new UnitsCard("Infectados","Naughty Dog",12, UnitsCard.AtackType.MR, UnitsCard.UnitType.Silver,new SetWeather());
              UnitsCard card38=new UnitsCard("Riley","Naughty Dog",11, UnitsCard.AtackType.RS, UnitsCard.UnitType.Silver,new SetIncrease());
              UnitsCard card39=new UnitsCard("GunMan","Naughty Dog",10, UnitsCard.AtackType.R, UnitsCard.UnitType.Silver,new IncreasePower());
              UnitsCard card40=new UnitsCard("Brave Ellie","Naughty Dog",18, UnitsCard.AtackType.MRS, UnitsCard.UnitType.Gold,new Average());



            UnitsCard card41=new UnitsCard("Michael","Rockstar",15,UnitsCard.AtackType.RS,UnitsCard.UnitType.Silver,new DeleteMorePowerCard());
            UnitsCard card42=new UnitsCard("Franklin","Rockstar",12,UnitsCard.AtackType.MS,UnitsCard.UnitType.Silver,new DeleteLessPowerCard());
           Clearance card43= new Clearance("Niko Bellic","Rockstar", new DeleteWeather());
            Clearance card44= new Clearance("Niko Bellic","Rockstar", new DeleteWeather());
            UnitsCard card45= new UnitsCard("Capo","Rockstar",14, UnitsCard.AtackType.S, UnitsCard.UnitType.Silver,new DeleteCardInGame());
           Increase card46= new Increase("Squad","Rockstar", new IncreaseRow4());
            UnitsCard card47=new UnitsCard("RealG","Rockstar",14, UnitsCard.AtackType.S, UnitsCard.UnitType.Silver,new IncreasePower());
       UnitsCard card48=new UnitsCard("RealG","Rockstar",14, UnitsCard.AtackType.S, UnitsCard.UnitType.Silver,new IncreasePower());

               
              
            UnitsCard card49=new UnitsCard("Young Ellie","Naughty Dog",15, UnitsCard.AtackType.M, UnitsCard.UnitType.Silver, new DeleteMorePowerCard());
            UnitsCard card50=new UnitsCard("Drake","Naughty Dog",16, UnitsCard.AtackType.R, UnitsCard.UnitType.Silver,new DeleteLessPowerCard() );
           UnitsCard card51=new UnitsCard("Drake","Naughty Dog",16, UnitsCard.AtackType.R, UnitsCard.UnitType.Silver,new DeleteLessPowerCard() );
            UnitsCard card52=new UnitsCard("Roman","Naughty Dog",12, UnitsCard.AtackType.S, UnitsCard.UnitType.Silver, new Steal() );
           UnitsCard card53= new UnitsCard("Roman","Naughty Dog",12, UnitsCard.AtackType.S, UnitsCard.UnitType.Silver, new Steal() );
            UnitsCard card54= new UnitsCard("Chloe","Naughty Dog",14, UnitsCard.AtackType.MS, UnitsCard.UnitType.Silver, new DeleteCardInGame());
            UnitsCard card55= new UnitsCard("Steve","Naughty Dog",11, UnitsCard.AtackType.MR, UnitsCard.UnitType.Silver,new PlusOne());
           UnitsCard card56= new UnitsCard("Fox","Naughty Dog",13, UnitsCard.AtackType.RS, UnitsCard.UnitType.Silver, new DeleteLessPowerCard());
            UnitsCard card57= new UnitsCard("Blonde","Naughty Dog",16, UnitsCard.AtackType.MR, UnitsCard.UnitType.Silver, new Steal());
             Increase card58= new Increase("Great Squad","Naughty Dog", new IncreaseRow2());
            Clearance card59= new Clearance("Brave Drake","Naughty Dog",new DeleteWeather());
           Clearance card60= new Clearance("Brave Drake","Naughty Dog",new DeleteWeather());
            UnitsCard card61= new UnitsCard("GunMan","Naughty Dog",10, UnitsCard.AtackType.R, UnitsCard.UnitType.Silver,new IncreasePower());
            UnitsCard card62= new UnitsCard("GunMan","Naughty Dog",10, UnitsCard.AtackType.R, UnitsCard.UnitType.Silver,new IncreasePower());













                
              

              Decks deck1 = new Decks(card1,card2,card3,card4,card5,card6, card7, card8,card9,card10,card11,card12,
              card13,card14,card15,card16,card17,card18,card19,  card33,card34,card35,card36,card41,card42,card43,
              card44,card45,card46,card47,card48  );
              
              Decks deck2 = new Decks(card20,card21,card22,card23,card24,card25,card26,card27,card28,card29,card30,card31,card32,
                      card37,card38,card39,card40,card49,card50,card51,card52,card53,card54,card55,card56,card57,card58,card59,card60,
                      card61,card62 );
          
              
              player1 = new Players(deck1, board1);
              player2 = new Players(deck2, board2);




       }
} 