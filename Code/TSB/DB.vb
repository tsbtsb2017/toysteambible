Option Strict Off
Option Explicit On
Module DB
	
    ' Install mysql
    ' Install MySQL ODBC Driver 3.51
	' Start the service
	' Login using the root     mysql.exe -uroot -p<pwd>
	'   - Create user tsb;
	'   - Create schema tsb;
	'   - Grant all on tsb.* to tsb;

    ' DSN Nolonger needed ---   Create ODBC System DSN called tsbdb   server=localhost  user=tsb  password=<blank>   database=tsb

    Public oMainForm As TSB_Generator
	Public sSql As String
	Public sRootPath As String
    Dim iCount As Integer = 0

	Public Structure MANUFACTURER_DETAILS
		Dim Manufacturer As String
		Dim Country As String
		Dim FlagCode As String
		Dim Notes As String
		Dim UpdateDate As String
	End Structure



    Public Sub LoadManufacturerData()

        Dim oC As New ADODB.Connection
        Dim oRs As ADODB.Recordset
        Dim i As Short
        Dim sInsert As String


        iCount = 0

        ' Connect to DB and begin transaction
        'oC.Open("dsn=tsbdb")
        ConnectToDb(oC)

        oC.BeginTrans()

        ' Drop engines table
        On Error Resume Next
        oC.Execute("drop table manufacturers")
        On Error GoTo 0

        ' Create steam engines table
        sSql = ""
        BS(("create table manufacturers"))
        BS(("(manufacturer  varchar(60),"))
        BS((" country  varchar(50),"))
        BS((" flag_code  varchar(3),"))
        BS((" manufacturer_notes text,"))
        BS((" update_date datetime)"))

        oC.Execute(sSql)

        ' Insert engines
        IM(oC, "A. Thieren & Sons", "Great Britain", "GBR", "TBA", "2013-04-22 07:58:00")
        IM(oC, "AB Alga", "Sweden", "SE", "AB Alga is a Swedish maker who, as far as we know, only made the one steam toy model.", "2009-07-15 22:17:00")
        IM(oC, "ADE", "Sweden", "SE", "More information about 'ADE' can be found here <a href='http://rolywilliams.com/ade_stationary.html'>http://rolywilliams.com/ade_stationary.html</a><br/>Swedish company ADE from Insjön started as a mail order company selling radio equipment during the 1920's. In late 1940's to 1960's they produced a series of stationary steam engines, tractors and train sets. The engines were sold by the post order company Clas Ohlson, also from the town of Insjön. A typical ADE disease is cracks in the boiler due to metal fatigue.", "2011-09-12 08:16:00")
        IM(oC, "Anton Bohaboy", "USA", "USA", "Anton Bohaboy (1888-1963) born in the Czech Republic (Bohemia) was a brilliant machinist. His most prolific work was done in the 40's and 50's. He had a small  machine shop in Rahway, NJ. He is credited with supplying Boucher with their later single and double Cyl. Marine plants and Boilers.   He made full models, Boilers, Engines and sold Castings", "2014-09-01 16:46:00")
        IM(oC, "Astromedia", "Germany", "GER", "Astromedia is a German company that makes cardboard kits of scientific instruments", "2009-04-7 22:17:00")
        IM(oC, "Bassett Lowke", "Great Britain", "GBR", "An old British manufacturer bought by Corgi in 1996 and revived with new models in 1999. http://www.bassettlowke.co.uk/", "2007-05-5 13:41:00")
        IM(oC, "Bengs Modellbau", "Germany", "GER", "Bengs Modellbau is a German company supplying model engine kits and parts.  http://www.bengs-modellbau.de/  ", "2014-08-23 10:53:00")
        IM(oC, "Beier", "United States", "USA", "TBA", "2015-07-06 08:15:00")
        IM(oC, "Bing", "Germany", "GER", "The Bing firm was established in about 1866 by Gebruder Bing and started life by selling toys. The firm moved on to its own toy production by 1879. However, the toy steam range seems to have only started about 1898.<br><br>Bing became one of the largest ever toy steam manufacturers and at its height employed about 5000 people. The firm seem to have changed their company logo a few times (at least 5) over the years and these marks and the Bing Cataloging system can help identify models and years of production.<br><br>Unfortunately, the firm ran into difficulties in the early 1930's and was sold off. Parts of the company seem to have been brought by Bub, Falk and Krauss who continued to make some of the Bing steam toys.", "2007-04-15 10:15:00")
        IM(oC, "Bindon", "South Africa", "ZA", "Prof Jeff Bindon of University of KZN in Natal designs kits and also does Pop Pop boats", "2014-03-22 09:55:00")
        IM(oC, "Bittleston", "Great Britain", "GBR", "Bittleston Ltd made small numbers of model engines which were given away or sold by 'Chronos'", "2014-09-14 20:10:00")
        IM(oC, "Bohm", "Germany", "GER", "TBA", "2007-04-15 10:15:00")
        IM(oC, "Bowman", "Great Britain", "GBR", "TBA", "2007-04-15 10:15:00")
        IM(oC, "Bowmans of Luton", "Great Britain", "GBR", "TBA", "2007-04-15 10:15:00")
        IM(oC, "Brimo", "New Zealand", "NZ", "Brimo engines were made by Brian Moss in Glenfield Auckland NZ and then in South Dunedin. In the North Island they were sometimes sold under the name 'Charles Stevenson' engines. Brimo engines were made in the 1960s and 1970s.  Brain was a tool and die maker by trade who retired and then made steam engines in the garage under his house.  All of the engine components were made by Brian and he adapted his equipment to suit each part's manufacturing requirements.", "2007-10-14 09:30:00")
        IM(oC, "Burnac", "Great Britain", "GBR", "TBA", "2007-04-15 10:15:00")
        IM(oC, "CAMEO", "Great Britain", "GBR", "TBA", "2014-01-09 11:41:00")
        IM(oC, "CAREAST", "Great Britain", "GBR", "TBA", "2014-01-09 11:46:00")
        IM(oC, "Carette", "Germany", "GER", "TBA", "2016-01-10 20:52:00")
        IM(oC, "Castle Products", "Great Britain", "GBR", "TBA", "2014-01-09 11:47:00")
        IM(oC, "CK", "Japan", "JP", "TBA", "2012-11-19 07:57:00")
        IM(oC, "Clyde Model Dockyard", "Great Britain", "GBR", "TBA", "2007-04-15 10:15:00")
        IM(oC, "Cotswold Heritage", "Great Britain", "GBR", "A UK steam engine model company based in Stratford upon Avon.  <a href='http://www.modelsteamenginesuk.com/index.html'> Company Website </a>", "2011-07-17 10:55:00")
        IM(oC, "Crescent Toys", "Great Britain", "GBR", "TBA", "2007-04-15 10:15:00")
        IM(oC, "Cyldon", "Great Britain", "GBR", "TBA", "2007-04-15 10:15:00")
        IM(oC, "C.Walker", "Great Britain", "GBR", "An acomplished modelmaker who scratch built engines", "2014-08-23 10:35:00")
        IM(oC, "David Auld", "New Zealand", "NZ", "David Auld started making steam toys around 1966 and made mobiles traction and a roller, stationary engines and locos and steam launches.  In 1988/89 he made his final batch of steam toys 27 steam locos.", "2007-04-15 10:15:00")
        IM(oC, "DEO", "Germany", "AR", "D.E.O. Engines were made in Argentina", "2008-12-11 07:45:00")
        IM(oC, "DGM", "Great Britain", "GBR", "TBA", "2014-01-12 10:30:00")
        IM(oC, "DMF Neustadt", "Germany", "GER", "Dampfmaschinenfabrik Neustadt", "2013-04-08 13:17:00")
        IM(oC, "Doll", "Germany", "GER", "TBA", "2007-04-15 10:15:00")
        IM(oC, "EKT", "Germany", "GER", "EKT engines and accessories were made in the former DDR", "2011-01-08 17:20:00")
        IM(oC, "Elmer Verburg", "USA", "USA", "Elmer Verburg, born 28 Aug 1908 died 7 Jan 1995, lived in Michigan, USA.  He made plans for the ""Elmers"" series of engines,  they were published drawings and are made in the thousands by model builders around the world.", "2014-09-01 17:32:00")
        IM(oC, "Empire", "USA", "USA", "TBA", "2007-04-15 10:15:00")
        IM(oC, "Eugene Beggs", "USA", "USA", "TBA", "2011-09-14 08:08:00")
        IM(oC, "Falk", "Germany", "GER", "Engines made by Joseph Falk in the early 1900s", "2008-10-25 11:42:00")
        IM(oC, "Fleischmann", "Germany", "GER", "TBA", "2007-04-15 10:15:00")
        IM(oC, "EPD", "Germany", "GER", " Eberhard Pässler, Dresden. ", "2007-05-06 10:15:00")
        IM(oC, "Gakken", "Japan", "JP", "TBA", "2007-04-16 18:40:00")
        IM(oC, "Gaselan", "Germany", "GER", "East German company making a single engine.", "2009-09-14 08:29:00")
        IM(oC, "Gee Cee", "???", "???", "Nothing is known of this manufacturer not even it's country, please let me know if you know any more.", "2013-08-01 08:15:00")
        IM(oC, "Gem", "Great Britian", "GBR", "Engines produced by Gem Products based in Wiltshire in the 1950s", "2008-10-25 11:48:00")
        IM(oC, "GPM", "Germany", "GER", "VEB Geräte und Pumpenbau, Merbelsrod", "2016-01-27 20:40:00")
        IM(oC, "Graham Industries", "USA", "USA", "TBA", "2012-08-07 10:20:00")
        IM(oC, "HAMPO", "Germany", "GER", "TBA", "2009-10-18 10:18:00")
        IM(oC, "Hawker", "Great Britian", "GBR", "TBA", "2013-09-29 18:30:00")
        IM(oC, "H.E. Boucher Mfg Co", "USA", "USA", "The Boucher Manufacturing Company, founded by H.E. Boucher, was an American toy company based in New York that specialized in toy boats and toy trains. <a href='http://www.tcawestern.org/boucher.htm'>Read More Here</a>", "2010-10-31 09:56:00")
        IM(oC, "Hielscher", "Germany", "GER", "Hielscher Dampfmodelle a company owned by Lutz Hielscher.<a href='http://www.hielscher-dampfmodelle.de'> Company Website</a>", "2011-06-30 07:57:00")
        IM(oC, "Hobbies", "Great Britian", "GBR", "TBA", "2007-04-15 10:15:00")
        IM(oC, "HOG", "Germany", "GER", "TBA", "2007-04-15 10:15:00")
        IM(oC, "Hornby", "Great Britian", "GBR", "TBA", "2007-04-15 10:15:00")
        IM(oC, "HSM", "Great Britian", "GBR", "Historic Steam Modeles. Historic Steam Models Ltd is the sole manufacturer of the very successful York ~ Bolton Mill Engine and Steam Plant and the Merlin Agricultural Engine. They are based in Billingshurst, West Sussex , England. <a href='http://historicsteammodels.com/about-us.htm'>Click here for company website</a>", "2011-03-27 09:48:00")
        IM(oC, "Ind-X", "USA", "USA", "Engines made in Los Angeles, designs based on Empire models?", "2013-01-27 11:30:00")
        IM(oC, "James Maiwald", "Germany", "GER", "James Maiwald is a German builder of model engines who sells his models on eBay (and on request) his website is <a href='http://www.kellergeist71.de/'>http://www.kellergeist71.de/</a>.  <br>  I own several of his models myself and can attest to their quality.", "2011-01-08 17:15:00")
        IM(oC, "JC-Steam", "France", "FR", "A manuafacturer of steam turbines. <a href='http://jc-steam.com'>Company website</a>", "2011-06-30 08:11:00")
        IM(oC, "Jean Comby", "France", "FR", "TBA", "2009-10-18 10:23:00")
        IM(oC, "Jensen", "USA", "USA", "Jensen Steam Engine Mfg. have been making model steam engines in Jeanette, Pennsylvania since 1932.  Founded by Tom Jensen Sr. it's still run by his family to this day.  Visit their website for more information:  <a href='http://jensensteamengines.com'>jensensteamengines.com</a>", "2007-04-15 10:15:00")
        IM(oC, "John Haining", "Great Britian", "GBR", "TBA", "2007-04-15 10:15:00")
        IM(oC, "John Ericsson", "Sweden", "SE", "TBA", "2013-02-16 15:43:00")
        IM(oC, "K-D SteamSupreme", "South Africa", "ZA", "K-D Steam Supreme produce miniature steam powered & Hot air engines which are manufactured by Kevin Doveton of Napier, South Africa since 2003. </p><p>All are hand crafted, scratch built with no castings used.", "2013-04-22 08:05:00")
        IM(oC, "Karsten Gintschel", "Germany", "GER", "TBA", "2007-04-15 10:15:00")
        IM(oC, "Kleinemeier", "Germany", "GER", "Kleinemeier is a German maker who's current range consists of two models, a vertical boilered stationary and the ""Steam Engine House"".", "2009-07-15 22:15:00")
        IM(oC, "Kontax", "Great Britian", "GBR", "Kontax Engineering Ltd is small specialist engineering company staffed by a team of highly skilled and dedicated engineers.  They use CNC technology to make small model engines. <a href='http://www.stirlingengine.co.uk/'>Web site</a>", "2010-08-30 10:36:00")
        IM(oC, "Kookaburra", "Austrailia", "AUS", "TBA", "2007-04-15 10:15:00")
        IM(oC, "Cranko", "New Zealand", "NZ", "Donald Cranko's  Engineering factory was in Havelock North, New Zealand in the mid 1940s  a line of steam powered toys  under the name Movie Models were produced along side  General engineering . School pupils were employed, part time, to handle such tasks as toy painting, assembly etc. <nl>Production ceased in 1956 when Donald move to Kerikeri northland. The factory was leased to another firm but burnt down in 1959.", "2007-04-16 18:43:00")
        IM(oC, "Latimer Productions", "Great Britian", "GBR", "TBA", "2007-04-15 10:15:00")
        IM(oC, "L.C. Mason", "Great Britian", "GBR", "TBA", "2011-01-06 16:05:00")
        IM(oC, "Leybold", "Germany", "GER", "TBA", "2012-10-27 16:15:00")
        IM(oC, "Liney Machine", "USA", "USA", "<a href='http://lineymachine.googlepages.com/'>LineyMachine.com</a> is an American company offering model steam engine kits and pre-assembled versions (hand built by the designer Lance Liney).", "2007-04-21 10:38:00")
        IM(oC, "Line Mar", "Japan", "JP", "", "2008-12-11 10:38:00")
        IM(oC, "LS LOC", "Switzerland", "CH", "Based in Basel making engines in the 1980s", "2009-10-18 10:14:00")
        IM(oC, "M. Stauffer", "Germany", "GER", "TBA", "2015-01-04 12:03:00")
        IM(oC, "Major Toy", "USA", "USA", "Major Toy of Ecorse Michigan, U.S.A who manufactured steam toys from the early 1940s onwards", "2008-11-01 09:53:00")
        IM(oC, "Mamod", "Great Britian", "GBR", "TBA", "2007-04-15 10:15:00")
        IM(oC, "Mamod Accessories", "Great Britain", "GBR", "TBA", "2007-04-15 10:15:00")
        IM(oC, "Markie", "Great Britian", "GBR", "TBA", "2013-04-08 13:25:00")
        IM(oC, "Marklin", "Germany", "GER", "TBA", "2007-04-15 10:15:00")
        IM(oC, "Maxitrak", "Great Britian", "GBR", "TBA", "2015-05-06 08:05:00")
        IM(oC, "Mastrand", "Great Britain", "GBR", "Mastrand engines were made in Buckinghamshire.", "2007-04-15 10:15:00")
        IM(oC, "Maxwell Hemmens", "Great Britian", "GBR", "TBA", "2007-04-15 10:15:00")
        IM(oC, "Meccano", "Great Britian", "GBR", "The British construction toy company also brought out some steam engines to integrate with their model kits", "2008-10-11 10:11:00")
        IM(oC, "Mercer", "Great Britian", "GBR", "TBA", "2007-04-15 10:15:00")
        IM(oC, "Mersey Model Co Ltd", "Great Britain", "GBR", "TBA", "2007-04-15 10:15:00")
        IM(oC, "Merkur Toys", "Czech Republic", "CZ", "TBA", "2013-12-11 22:15:00")
        IM(oC, "MF Steam", "Great Britian", "GBR", "MF Steam is a company run by Ian Grantham (MamodFan), manufacturing replica engines and spare parts. <a href='http://www.mfsteam.com/'>Web site</a>", "2007-10-14 09:51:00")
        IM(oC, "Microcosm", "China", "CN", "TBA", "2013-06-17 11:54:00")
        IM(oC, "Midwest", "USA", "USA", "TBA", "2007-04-15 10:15:00")
        ' Replaced by Scorpion IM(oC, "Model Engineering Products", "Austrailia", "AUS", "TBA", "2007-04-15 10:15:00")
        IM(oC, "MSS", "Great Britian", "GBR", "TBA", "2007-04-15 10:15:00")
        IM(oC, "Mr Power", "China", "CN", "TBA", "2013-02-16 15:44:00")
        IM(oC, "Multum", "Great Britian", "GBR", "Made by Ward & Goldstone Plastics Ltd, Tottenham Court Road, London.", "2009-08-09 21:15:00")
        IM(oC, "Opitec", "Great Britian", "GBR", "TBA", "2009-07-15 22:15:00")
        IM(oC, "Other", "???", "???", "Other manufactures and one off model makers are listed here.", "2012-02-26 20:25:00")
        IM(oC, "Owen", "Great Britian", "GBR", "Engines made by Steve Owen", "2015-10-17 12:15:00")
        IM(oC, "Paul Cooper", "Ireland", "IE", "TBA", "2016-01-10 20:59:00")
        IM(oC, "Parken", "Australia", "AUS", "TBA", "2012-02-16 15:52:00")
        IM(oC, "Peake Engines", "Australia", "AUS", "Ben Peake makes model engines in a small workshop, each is signed.  <a href='http://peake-engines.com/'>Visit Peake Engines</a>", "2010-08-08 09:00:00")
        IM(oC, "Philcraft", "Great Britian", "GBR", "TBA", "2007-04-15 10:15:00")
        IM(oC, "Plane Products", "Great Britian", "GBR", "TBA", "2008-04-13 08:15:00")
        IM(oC, "Plank", "Germany", "GER", "The Plank firm was founded in Nurenberg , Germany , in 1866 and specialised in steam engines and optical toys ( Magic lanterns ). About 1890 the firm began also producing mechanical and steam driven train sets and physics teaching sets and equipment .About 1900 they had produced some 80000 steam engines and 150000 magic lanterns.  In 1934 the firm sold out to the Scheller brothers who stopped toy production and concentrated on optical devices such as still an film projection material under the name 'Noris Plank'", "2011-03-11 14:32:00")
        IM(oC, "PM Research", "USA", "USA", "TBA", "2007-04-15 10:15:00")
        IM(oC, "Powertoy", "Canada", "CA", "TBA", "2015-05-06 08:08:00")
        IM(oC, "PREFO", "Germany", "GER", "TBA", "2012-10-24 08:08:00")
        IM(oC, "Quality", "Great Britian", "GBR", "TBA", "2014-02-03 20:20:00")
        IM(oC, "R. Reichelt", "Germany", "GER", "TBA", "2011-01-08 17:05:00")
        IM(oC, "Rattandeep", "India", "IN", "A manufacturer of tin toys. See their website <a href='http://www.angelfire.com/extreme2/rattandeepenterprise/index.html'>here.</a>", "2012-08-03 07:53:00")
        IM(oC, "Reeves", "Great Britain", "GBR", "TBA", "2012-02-25 11:09:00")
        IM(oC, "Renown", "Austrailia", "AUS", "TBA", "2011-11-24 08:11:00")
        IM(oC, "Robert Fulton", "USA", "USA", "Robert Fulton Line of engines produced by MarvIndustries, Chicago U.S.A. ", "2007-04-15 10:15:00")
        IM(oC, "Rose Boats", "South Africa", "ZA", "Alan Raubenheimer has been making and selling tinplate pop-pop steam boats since 1986.", "2014-10-26 19:30:00")
        IM(oC, "Roundhouse Engineering", "Great Britain", "GBR", "TBA", "2012-03-22 08:13:00")
        IM(oC, "Saito", "Japan", "JP", "TBA", "2011-10-28 16:21:00")
        IM(oC, "Schoenner", "Germany", "GER", "TBA", "2012-03-10 18:55:00")
        IM(oC, "Scorpion", "Australia", "AUS", "Scorpion was founded by Ted Wallis and Ted Peell in late 1944 (also known as Model Engineering Products) and made toy stationary and railway steam engines. <a href='http://www.freewebs.com/ozsteam/scorpion.htm'>More history here</a>", "2010-11-27 12:46:00")
        IM(oC, "SIM Co", "USA", "USA", "Specialty Instrument and Machine Co.", "2010-06-24 09:24:00")
        IM(oC, "SEIG", "China", "CN", "A company that makes lathes and other metalwork items, that also occasionally makes other models", "2014-09-14 18:55:00")
        IM(oC, "SEL", "Great Britian", "GBR", "Towards the end of the war many British firms were looking for ways to diversify away from arms and military manufacture. One such firm was Signalling Equipment Limited, or SEL as it is more commonly known.  <a href='../sel_info.htm'>Click here</a> for more information", "2007-04-15 10:15:00")
        IM(oC, "Start", "Great Britain", "GBR", "TBA", "2012-08-27 12:26:00")
        IM(oC, "Steamco", "Austrailia", "AUS", "TBA", "2007-04-15 10:15:00")
        IM(oC, "Steam Craft", "New Zealand", "NZ", "Steam Craft engines are made by Graham Heavey of Wanganui, New Zealand.  He has been making engines for many years, mainly based on his own design.  In 1996 Graham suffered a severe brain injury as a result of an assault while working as a locksmith, this meant that he lost the use of his '3d vision' i.e. only seeing things 'one side at a time instead of a whole picture'. Luckily he was able to work on this and has been able to continue to make the engines as beautifully as ever.  As he is unable to work full time it has become skill to keep his brain challenged and allow him to earn some extra funds. Graham would ideally like to make a business from this skill but is only able to produce engines as his injury allows. He currently sells these engines on <a href='http://www.trademe.co.nz'>www.trademe.co.nz</a>.", "2011-11-24 08:18:00")
        IM(oC, "Steamcraft", "Great Britain", "GBR", "Steamcraft UK existed between 1976 and 1982 and was owned by David Taylor and quite a few different live steam models were made within this period.", "2012-03-22 08:01:00")
        IM(oC, "Stevens Model Dockyard", "Great Britain", "GBR", "Based in London England making locomotives in the late 1800s until 1920s", "2011-09-14 08:03:00")
        IM(oC, "Stuart Turner", "Great Britain", "GBR", "TBA", "2007-04-15 10:15:00")
        IM(oC, "Sussex Steam", "Great Britain", "GBR", "Sussex Steam Co. is based in a small village in Sussex on the south coast of England and is a small company specialising in the design and development of a unique range of historical model steam engines. The company was created in 2002.  <a href='http://www.sussexsteam.co.uk'>Company Website</a>", "2010-10-03 10:44:00")
        IM(oC, "Swan", "Great Britain", "GBR", "In 1920-1925, the Hobran engineering company ltd of Wolverhampton produced the Swan Steam toys for a retailer with the same name. Typical for the Swan engines is the short cupper boiler and square chimney.", "2012-08-27 12:24:00")
        IM(oC, "T.E.Haynes", "Great Britain", "GBR", "Published many model plans in books designed for schools", "2014-07-18 14:12:00")
        IM(oC, "Tekno-Langes", "Denmark", "DK", "TBA", "2011-01-10 21:30:00")
        IM(oC, "TMY", "Japan", "JP", "TBA", "2013-04-07 11:33:00")
        IM(oC, "Tony Green", "Great Britain", "GBR", "Tony Green Steam Models are a family business based in Lincoln UK  <a href='http://www.tonygreensteammodels.co.uk/'>Website Site</a>", "2014-03-22 10:00:00")
        IM(oC, "Tucher and Walther", "Germany", "GER", " Tucher and Walther was established in Nurenburg Germany in 1977 and started making steam toys in 1982. Much more information can be found <a href='http://www.puccimanuli.com/pages/toymakers.php?content_id=17'> here.</a>", "2012-04-02 20:30:00")
        IM(oC, "Unknown", "???", "???", "This is where engines of unknown manufacturer are placed.  If you can supply any information please contact us here contact@ToySteamBibile.org so that the database can be updated.", "2007-04-15 10:15:00")
        'IM(oC, "VEB", "East Germany", "GER", "VEB is an East German company who's main line of business is (I believe) car parts.", "2010-10-03 10:50:00")
        IM(oC, "Weeden", "USA", "USA", WeedenNotes(), "2007-04-15 10:15:00")
        IM(oC, "Welby", "India", "IN", "A toy manufacturer based in India", "2009-04-07 22:15:00")
        IM(oC, "Weller", "Great Britain", "GBR", "TBA", "2013-04-07 11:31:00")
        IM(oC, "Wells", "Great Britain", "GBR", "In 1972 Kenneth Wells, a teacher at Manor Court School, Portsmouth, England, wrote three text books under the general title of Step by Step Metalwork. Book three only contained two projects. How to make a stationary toy steam model and how to make a toy steam traction engine.<br><br>Unfortunately, by the late 1980's, changes in both Health and Safety Laws and in the education system's curriculum requirements meant that these models stopped being made.<br><br>These models were made as school projects which means they are made to very differing standards and finish. They are still fairly easy to find on ebay and are both great fun and a good addition to a toy steam collection.", "2007-04-15 10:15:00")
        IM(oC, "Wiggers", "Germany", "GER", "TBA", "2007-04-15 10:15:00")
        IM(oC, "Wilesco", "Germany", "GER", "TBA", "2007-04-15 10:15:00")
        IM(oC, "Wilhelm Bischoff", "Germany", "GER", "Wilhelm Bischoff built engines in Dresden Germany around the 1920s", "2015-01-04 11:39:00")
        IM(oC, "Wilson Bros", "Great Britain", "GBR", "TBA", "2012-07-06 07:20:00")
        IM(oC, "Wilson Foundries", "Canada", "CA", "TBA", "2013-06-17 11:40:00")
        IM(oC, "Wormar", "Great Britain", "GBR", "TBA", "2007-04-15 10:15:00")
        IM(oC, "Zongshan", "China", "CN", "Based in Guangdong China.", "2013-02-16 15:48:00")



        oC.CommitTrans()

    End Sub

    Sub ConnectToDb(ByRef oC As ADODB.Connection)
        ' oC.Open("Driver={MySQL ODBC 5.2w Driver};Server=localhost;Database=tsb; User=tsb;Password=;Option=3;")

        ' n.b. This targets 32 bit driver and so needs a different compile 
        oC.Open("Driver=SQLite3 ODBC Driver;Database=" + sRootPath + "\code\tsb.sqlite")
    End Sub

	Sub FindManufacturerDetails(ByRef sManufacturer As String, ByRef tyManufacturer As MANUFACTURER_DETAILS)
		
		Dim oC As New ADODB.Connection
		Dim oMRs As ADODB.Recordset
        Dim tyEmpty As New MANUFACTURER_DETAILS
        'Dim i As Integer
        'Dim s As String
		
		'UPGRADE_WARNING: Couldn't resolve default property of object tyManufacturer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		tyManufacturer = tyEmpty
		oC.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		
        'oC.Open("dsn=tsbdb")
        ConnectToDb(oC)
		oC.BeginTrans()
		
		oMRs = oC.Execute("select * from manufacturers where manufacturer='" & sManufacturer & "'")
		
		If oMRs.RecordCount <> 1 Then
			MsgBox("Warning: " & sManufacturer & " not found.")
		Else
			tyManufacturer.Manufacturer = sManufacturer
			tyManufacturer.Country = oMRs.Fields("country").Value
			tyManufacturer.FlagCode = oMRs.Fields("flag_code").Value
			tyManufacturer.Notes = oMRs.Fields("manufacturer_notes").Value
            tyManufacturer.UpdateDate = Microsoft.VisualBasic.Format(oMRs.Fields("update_date").Value, "dd-MMM-yyyy HH:mm:ss")
			
		End If
		
		
		oC.CommitTrans()
		oC.Close()
		
		
		
	End Sub

	
	Sub BS(ByRef sString As String)
		sSql = sSql & sString
	End Sub
    Sub IE(ByRef oC As ADODB.Connection, ByRef iEngineId As Integer, ByRef sManufacturer As String, ByRef sEngineModel As String, ByRef sEngineDate As String, ByRef sOwner As String, ByRef sOwnerURL As String, ByRef iNumberOfImages As Short, ByRef sNotes As String, ByRef sDate As String, ByVal iSortField As Integer, Optional ByVal sVideo As String = "")

        Dim sInsert As String

        Dim sDir As String

        sInsert = "insert into steam_engines (steam_engine_id,manufacturer,engine_model,engine_date,owner_name,owner_url,engine_notes,number_of_images,update_date,sort_field,video_url) "
        sSql = "values ("
        BS((CStr(iEngineId) & ","))
        BS(("'" & Replace(sManufacturer, "'", "''") & "',"))
        BS(("'" & sEngineModel & "',"))
        BS(("'" & sEngineDate & "',"))
        BS(("'" & sOwner.Replace("'", "''") & "',"))
        BS(("'" & sOwnerURL & "',"))
        BS(("'" & Replace(sNotes, "'", "''") & "',"))
        BS((CStr(iNumberOfImages) & ","))
        BS(("'" & sDate & "'," + iSortField.ToString + ",'" + sVideo + "')"))

        oC.Execute(sInsert & sSql)


        ' Ensure the manufacturer directory exists
        On Error Resume Next
        sDir = Replace(sManufacturer, " ", "_")
        System.IO.Directory.CreateDirectory(sRootPath & "\" & sDir)
        'MkDir()
        On Error GoTo 0


        iCount += 1
        oMainForm.lblUp1.Text = "Engine:" + iCount.ToString
        Application.DoEvents()


    End Sub
	
	Sub IM(ByRef oC As ADODB.Connection, ByRef sManufacturer As String, ByRef sCountry As String, ByRef sFlagCode As String, ByRef sText As String, ByRef sDate As String)
		
		Dim sInsert As String
		
        'Dim sDir As String
		
		sInsert = "insert into manufacturers (manufacturer,country,flag_code,manufacturer_notes,update_date) "
		sSql = "values ("
		BS(("'" & Replace(sManufacturer, "'", "''") & "',"))
		BS(("'" & sCountry & "',"))
		BS(("'" & sFlagCode & "',"))
		BS(("'" & Replace(sText, "'", "''") & "',"))
		BS(("'" & sDate & "')"))
		
		oC.Execute(sInsert & sSql)

        iCount += 1
        oMainForm.lblUp1.Text = "Manufacturer:" + iCount.ToString
        Application.DoEvents()


		
	End Sub
	
	
	Function WeedenNotes() As String
		
		Dim s As String
		
		
		s = "The Weeden Manufacturing Company was started by William N. Weeden in the 1880s in New Bedford, Massachusetts.  The company first produced oil lamp burners and tin plate household items.  Through his dealings he came to meet the owner of the ""Youth's  Companion""  magazine where they struck up a deal to produce toy steam engines to give away as premiums for his magazine.  The engine that Weeden produced was the Weeden No.1 which was priced at $1.00 and held a patent date of May 19, 1885, and  manufactured up to 1905.  Other products he made was comb cases, match safes and the Weeden Magic Lantern."
		
		s = s & "<br><br>William N. Weeden died in 1891 and taking control of the company was a long time employee and salesman, William Ritchie."
		
		s = s & "<br><br>In the 1890's the Weeden Company expanded their line of steam engines featuring cast iron bases, large brass boiler, nickel plating and more realistic looking steam engines.  At this time was the 'glory' days as steam was the power source in factories and heavy equipment.   This gave a direct relationship kids could see how power was produced."
		
		s = s & "<br><br>In the early years the engine was run exclusively on wood alcohol with exception of the N0.20 which could also be run on kerosene or heating oil as well as alcohol. In 1926-27 electric heat was introduced on some engines and in the same period, various models were fitted with electric heat and given new model numbers.  By 1940 there were at least 110 different steam engines that Weeden had produced."
		
		s = s & "<br><br>In 1942 Weeden was sold to National Playthings.  The steam craze was over and manufactures across the country had abandon steam and now used electric motors and diesel engines.  The new owners trimmed the  product line down to six engines and only two heated with alcohol.  1952 was the last of the Weeden company.   Behind the 110+ different models, plus other Weeden toys, Weeden left a memorable legacy."
		
		
		
		WeedenNotes = s
		
		
	End Function
	Public Sub LoadSteamData()
		
		Dim oC As New ADODB.Connection
		Dim oRs As ADODB.Recordset
		Dim i As Short
		Dim sInsert As String
		
		' Connect to DB and begin transaction
        ' oC.Open("dsn=tsbdb")
        ConnectToDb(oC)

        oC.BeginTrans()

        ' Drop engines table
        On Error Resume Next
        oC.Execute("drop table steam_engines", 0)
        On Error GoTo 0

        iCount = 0
        ' Create steam engines table
        sSql = ""
        BS("create table steam_engines")
        BS("(steam_engine_id integer,")
        BS("manufacturer  varchar(60),")
        BS(" engine_model  varchar(50),")
        BS("engine_date  varchar(30),")
        BS("owner_name  varchar(60),")
        BS("owner_url  varchar(120),")
        BS("engine_notes text,")
        BS("number_of_images  integer,")
        BS("update_date datetime, sort_field integer, video_url varchar(120))")

        oC.Execute(sSql)

        ' Insert engines
        IE(oC, 1, "Clyde Model Dockyard", "Outboard Engine", "1932", "Odilon Marcenaro (MooseMan)", "http://www.MooseMan.org.uk/", 1, "The last engine made by Clyde Model Dockyard", "2007-03-31 08:40:00", 0)

        IE(oC, 2, "Mersey Model Co Ltd", "52R", "1940", "Odilon Marcenaro (MooseMan)", "http://www.MooseMan.org.uk/", 1, "Mersey 52R - R denotes the presence of the reversing valve. The other suffix that can be found on Mersey engines is 'G', denoting 'Geared'.", "2007-03-31 08:40:00", 0)

        IE(oC, 3, "Latimer Productions", "Plane L4", "circa 1950", "Odilon Marcenaro (MooseMan)", "http://www.MooseMan.org.uk/", 1, "Latimer only made two engines - this one, and the bigger L5.", "2007-03-31 08:40:00", 0)

        IE(oC, 4, "Mamod", "SE2", "1953-1954", "Chuck Potts (oldstuff)", "", 1, "", "2007-03-31 08:40:00", 500)

        IE(oC, 5, "Bowman", "M135", "???", "Sandy Hunter (sandman)", "http://www.freewebs.com/sandmansteamshack/index.htm", 2, "Owned and restored by sandman.", "2007-03-31 08:40:00", 0)

        IE(oC, 6, "Bowman", "M101", "circa 1930", "Odilon Marcenaro (MooseMan)", "http://www.MooseMan.org.uk/", 1, "Bowman's biggest. The flywheel weighs a pound. Fully restored.", "2007-03-31 08:40:00", 0)

        IE(oC, 7, "Bowman", "M122", "circa 1930", "Odilon Marcenaro (MooseMan)", "http://www.MooseMan.org.uk/", 1, "The large twin cylinder model. Fully restored", "2007-03-31 08:40:00", 0)

        IE(oC, 8, "Bowman", "M135", "circa 1930", "Odilon Marcenaro (MooseMan)", "http://www.MooseMan.org.uk/", 1, "Bowman's most popular engine. Mostly original condition, apart from baseplate and decal.", "2007-03-31 08:40:00", 0)

        IE(oC, 9, "Bowman", "M140", "circa 1930", "John Chapman (formerly owned by MooseMan)", "", 1, "The small twin cylinder model. Original condition.", "2007-03-31 08:40:00", 0)

        IE(oC, 10, "Bowman", "M158", "circa 1930", "Odilon Marcenaro (MooseMan)", "http://www.MooseMan.org.uk/", 1, "Also available with optional chimney. Fully restored.", "2007-03-31 08:40:00", 0)

        IE(oC, 11, "Bowmans of Luton", "PW203", "circa 1947", "Odilon Marcenaro (MooseMan)", "http://www.MooseMan.org.uk/", 1, "Company is called: Bowman and engines were made in Luton but there no connection whatsoever to the 1930's Bowman company. Original condition apart from repainted baseplate.", "2007-03-31 08:40:00", 0)

        IE(oC, 12, "Bowman", "M180", "circa 1936", "Odilon Marcenaro (MooseMan)", "http://www.MooseMan.org.uk/", 1, "Smallest and latest in the production. Mazak flywheel and tinplate chimney", "2007-03-31 08:40:00", 0)

        IE(oC, 13, "Mamod", "TE1A", "1979", "mc_mc", "", 2, "This engine was bought from eBay for £75 in Jan 2007.  It's my pride and joy and is on display in my living room.", "2007-03-31 08:40:00", 0)

        IE(oC, 14, "Mamod", "MM1", "???", "Sandy Hunter (sandman)", "http://www.freewebs.com/sandmansteamshack/index.htm", 2, "", "2007-03-31 08:40:00", 0)

        IE(oC, 15, "Bowman", "M140", "???", "Sandy Hunter (sandman)", "http://www.freewebs.com/sandmansteamshack/index.htm", 2, "", "2007-03-31 08:40:00", 0)

        IE(oC, 16, "Mamod", "MM1", "1946", "Mamodman123", "http://www.mamodsteam.tk/", 1, "Mamod Minor 1 Flatbase version.", "2007-03-31 08:40:00", 0)

        IE(oC, 17, "Mamod", "MM1", "1957", "Mamodman123", "http://www.mamodsteam.tk/", 1, "", "2007-03-31 08:40:00", 0)

        IE(oC, 18, "Mamod", "MM1", "1975", "Mamodman123", "http://www.mamodsteam.tk/", 1, "", "2007-03-31 08:40:00", 0)

        IE(oC, 19, "Mamod", "MM2", "1953", "Mamodman123", "http://www.mamodsteam.tk/", 1, "", "2007-03-31 08:40:00", 0)

        IE(oC, 20, "Mamod", "MM2", "1958 - 1962", "Mamodman123", "http://www.mamodsteam.tk/", 1, "", "2007-03-31 08:40:00", 0)

        IE(oC, 21, "Mamod", "SL1", "1980 - 1989", "Mamodman123", "http://www.mamodsteam.tk/", 1, "", "2007-03-31 08:40:00", 0)

        IE(oC, 22, "Mamod", "SL2", "1980 - 1981", "Mamodman123", "http://www.mamodsteam.tk/", 1, "", "2007-03-31 08:40:00", 0)

        IE(oC, 23, "Mamod", "SL4", "???", "Mamodman123", "http://www.mamodsteam.tk/", 1, "Princess of Wales.  Only 250 ever produced.", "2007-03-31 08:40:00", 0)

        IE(oC, 24, "Mamod", "SL1k", "1983 - 1989", "Mamodman123", "http://www.mamodsteam.tk/", 1, "", "2007-03-31 08:40:00", 0)

        IE(oC, 25, "Mamod", "SE2", "1946", "Mamodman123", "http://www.mamodsteam.tk/", 1, "Interesting pre-war features.", "2007-03-31 08:40:00", 200)

        IE(oC, 26, "Mamod", "SE2", "1948", "Mamodman123", "http://www.mamodsteam.tk/", 1, "", "2007-03-31 08:40:00", 300)

        IE(oC, 27, "Mamod", "SE2", "1954 - 1957", "Mamodman123", "http://www.mamodsteam.tk/", 1, "", "2007-03-31 08:40:00", 600)

        IE(oC, 28, "Mamod", "SE2", "1964 - 1967", "Mamodman123", "http://www.mamodsteam.tk/", 1, "", "2007-03-31 08:40:00", 1000)

        IE(oC, 29, "Mamod", "SE2A", "1967 - 1972", "Mamodman123", "http://www.mamodsteam.tk/", 1, "", "2007-03-31 08:40:00", 0)

        IE(oC, 30, "Mamod", "TE1", "1963 - 1964", "Mamodman123", "http://www.mamodsteam.tk/", 1, "The first ever TE1", "2007-03-31 08:40:00", 0)

        IE(oC, 31, "Mamod", "SR1A", "1967 - 1968", "Mamodman123", "http://www.mamodsteam.tk/", 1, "", "2007-03-31 08:40:00", 0)

        IE(oC, 32, "Mamod", "SW1", "1972 - 1976", "Mamodman123", "http://www.mamodsteam.tk/", 1, "Green version.", "2007-03-31 08:40:00", 0)

        IE(oC, 33, "Mamod", "DV1", "1989 - 1991", "Mamodman123", "http://www.mamodsteam.tk/", 1, "", "2007-03-31 08:40:00", 0)

        IE(oC, 34, "Mamod", "SA1L", "2000", "Mamodman123", "http://www.mamodsteam.tk/", 1, "Limosine", "2007-03-31 08:40:00", 0)

        IE(oC, 35, "Hobbies", "SE1", "1936", "Mamodman123", "http://www.mamodsteam.tk/", 1, "", "2007-03-31 08:40:00", 10)

        IE(oC, 36, "Mamod", "SE4", "1937 - 1939", "Mamodman123", "http://www.mamodsteam.tk/", 3, "", "2007-03-31 08:40:00", 0)

        IE(oC, 37, "Mamod", "SE3", "1957 - 1958", "Mamodman123", "http://www.mamodsteam.tk/", 1, "", "2007-03-31 08:40:00", 0)

        IE(oC, 38, "Mamod", "SE3", "1958 - 1962 roughly", "Mamodman123", "http://www.mamodsteam.tk/", 1, "", "2007-03-31 08:40:00", 0)

        IE(oC, 39, "Mamod", "SE3", "1976 - 1979 roughly", "Mamodman123", "http://www.mamodsteam.tk/", 1, "Badged Griffin and George", "2007-03-31 08:40:00", 0)

        IE(oC, 40, "Mamod", "SP1", "1979 - 1984", "Mamodman123", "http://www.mamodsteam.tk/", 1, "This one 1981.", "2007-03-31 08:40:00", 0)

        IE(oC, 41, "Mamod", "SP4", "2002 (October!)", "Mamodman123", "http://www.mamodsteam.tk/", 1, "", "2007-03-31 08:40:00", 0)

        IE(oC, 42, "Mamod", "SC2", "???", "???", "", 2, "Pictures by Mike Newton (mj) taken at Kempton Park Toy Steam Weekend 2007", "2007-03-31 08:40:00", 0)

        IE(oC, 43, "Mamod", "SE4 Prototype", "???", "???", "", 4, "The SE4 Prototype. Pictures by Mike Newton (mj) taken at Kempton Park Toy Steam Weekend 2007", "2007-03-31 08:40:00", 0)

        IE(oC, 44, "Mamod", "SC4", "???", "???", "", 2, "Pictures by Mike Newton (mj) taken at Kempton Park Toy Steam Weekend 2007", "2007-03-31 08:40:00", 0)

        IE(oC, 45, "Mamod", "TE1", "1965", "Lewis", "http://www.lewismamods.piczo.com ", 2, "", "2007-03-31 08:40:00", 0)

        IE(oC, 46, "Mercer", "Type 1", "2006", "seven.mpd", "", 1, "2006 Mercer Type 1, assembled and painted myself.", "2007-03-31 08:40:00", 0)

        IE(oC, 47, "Mamod", "SP5", "1975-1984", "Lewis", "http://www.lewismamods.piczo.com ", 2, "", "2007-03-31 08:40:00", 0)

        IE(oC, 48, "Mamod", "SP6", "2006", "Lewis", "http://www.lewismamods.piczo.com ", 2, "", "2007-03-31 08:40:00", 0)

        IE(oC, 49, "Mamod", "SP4", "1975-1984", "Lewis", "http://www.lewismamods.piczo.com ", 2, "Badged Griffin and George, a special brand manufactured by Mamod for use in schools.", "2007-03-31 08:40:00", 0)

        IE(oC, 50, "Mamod", "SP3", "???", "Lewis", "http://www.lewismamods.piczo.com ", 1, "Meccano SP3 Steam Engine", "2007-03-31 08:40:00", 0)

        IE(oC, 51, "Mamod", "SR1", "1962 - 1963", "Dauntless", "http://dauntless-steam-engines.webs.com/", 1, "", "2007-04-01 09:05:00", 0)

        IE(oC, 52, "Mamod", "SE1", "1958", "Dauntless", "http://dauntless-steam-engines.webs.com/", 1, "", "2007-04-01 09:05:00", 700)

        IE(oC, 53, "Mamod", "SA1", "1976", "Dauntless", "http://dauntless-steam-engines.webs.com/", 1, "", "2007-04-01 09:05:00", 0)

        IE(oC, 54, "Mamod", "TE1A", "1967", "Dauntless", "http://dauntless-steam-engines.webs.com/", 1, "Straight lever type.", "2007-04-01 09:05:00", 0)

        IE(oC, 55, "Mastrand", "Steam Roller", "1950s", "Dauntless", "http://dauntless-steam-engines.webs.com/", 1, "Sold by Gamages of London Eric Malins (Mamod) bought one and thought I can build a better engine than that and Made the first Mamod SR1.", "2007-04-01 09:05:00", 0)

        IE(oC, 56, "Cyldon", "13-2", "circa 1946", "Roly Williams", "http://rolywilliams.com/cyldon_13-2.html", 1, "Single cylinder, single acting, semi-rotative valve. 3 wick meths burner. Overall length 360mm.", "2007-04-01 09:05:00", 0)

        IE(oC, 57, "Midwest", "Fantail Launch", "1995", "Roly Williams", "http://rolywilliams.com/midwest_fantail_launch.html", 2, "Supplied as two kits, one for the hull and one for the steam engine. Fitted with radio control on the tiller. Built and customised by Roly Williams and named 'Firebird'. Overall length 480mm. Single cylinder, single acting, oscillating cylinder. Vertical flue-tube boiler, originally designed to be fired with Sterno fuel (usually fired with broken up Esbit tablets).", "2007-04-01 09:05:00", 0)

        IE(oC, 58, "Philcraft", "Jenny Wren", "1994", "Roly Williams", "http://rolywilliams.com/philcraft_jenny_wren.html", 2, "Single cylinder single acting oscillating cylinder. Overall height 78mm. Vertical flue-tube boiler, fired with a single wick meths burner. Based on Tubal Cain's design published in 'Building Simple Model Steam Engines'. I don't know if Tubal Cain had any connection with Philcraft. Maybe he and Phil Gravet (the proprietor of Philcraft) were one and the same. 'Tubal Cain' was almost certainly a nom de plume.", "2007-04-01 09:05:00", 0)

        IE(oC, 59, "Wells", "Stationary", "circa 1970", "Roly Williams", "http://rolywilliams.com/wells_stationary.html", 1, "Probably made in a school metalwork class any time after about 1972. Restored by Roly Williams 2007. Single cylinder, single acting, oscillating cylinder. Copper boiler fired by a 3 wick meths burner. Overall length 260mm.", "2007-04-01 09:05:00", 0)

        IE(oC, 60, "Bowmans of Luton", "PW201", "1946 - 1950", "Tony Muir (tmuir)", "http://www.freewebs.com/ozsteam/index.htm", 1, "", "2007-04-01 09:05:00", 0)

        IE(oC, 61, "Scorpion", "Vertical Scorpion", "1947 - 1956", "Tony Muir (tmuir)", "http://www.freewebs.com/ozsteam/index.htm", 3, "Several variations around with different style cast bases but all have same flywheel and circular holes in firebox. Scorpion is rumoured to of made a mobile as well.", "2007-04-01 09:05:00", 0)

        IE(oC, 62, "Jensen", "Jensen #5", "late 1940s", "IndianaRog", "http://www.indianarog.com", 1, "Late 1940's Jensen #5 oscillator, solid cast iron engine, cast flywheel, solid pine base, electrically heated. Only goes one direction but gets there fast!", "2007-04-01 09:05:00", 0)

        IE(oC, 63, "Jensen", "Jensen #10", "1946 - 1947", "IndianaRog", "http://www.indianarog.com", 1, "1946-47 Jensen #10 with horseshoe magnet style inline generator, solid cast iron engine, cast flywheel, solid wood base, electrically heated. Built along lines of first generator design by Thomas Edison", "2007-04-01 17:55:00", 0)

        IE(oC, 64, "Jensen", "Jensen #10", "1951", "IndianaRog", "http://www.indianarog.com", 1, "1951 (single year) Jensen #10, with round magnet style generator machined from a single piece of cast iron, solid cast iron engine, cast flywheel, plywood base, electrically heated. Transition design of generator between prior horseshoe magnet style and later 3 piece magnet style generators.  Made only in 1951 as a solid round form...quite rare given short production period", "2007-04-01 17:55:00", 0)

        IE(oC, 65, "Jensen", "Jensen #20 Big Power Plant", "mid 1980s", "IndianaRog", "http://www.indianarog.com", 1, "Mid 1980's with stand alone cast iron generator/lamp, solid cast iron engine, cast flywheel, plywood base, electrically heated. Reversible on the fly with proper Stevenson's linkage. ", "2007-04-01 17:55:00", 0)

        IE(oC, 66, "Jensen", "Jensen #25", "1937", "IndianaRog", "http://www.indianarog.com", 1, "1937 Jensen #25 with riveted boiler and large cylinder bearing 4 bolt pattern on face, solid cast iron engine, cast flywheel, solid pine base, electrically heated.  The second rarest Jensen I have. 1930's Jensens bore robins egg blue paint supposedly hand applied by Mrs. Jensen at the kitchen table.", "2007-04-01 17:55:00", 0)

        IE(oC, 67, "Jensen", "Jensen #25", "late 1930s", "IndianaRog", "http://www.indianarog.com", 1, "Late 1930's Jensen #25 with riveted boiler and predating Jensen reversing linkages, solid cast iron engine, cast flywheel, solid pine base, electrically heated.  A bit later version of the '4 bolt' Jensen #25, bearing smaller cylinder and before Jensen began installing reversing linkages.  Robins egg blue era and first with electric cord run out the base of the chimney stack vs. front of firebox.", "2007-04-01 17:55:00", 0)

        IE(oC, 68, "Jensen", "Jensen #25", "early 1960s", "IndianaRog", "http://www.indianarog.com", 1, "Early 1960's Jensen #25, solid cast iron engine, cast flywheel, plywood base, proper Stevensons reversing linkage, electrically heated. My first Jensen purchase which led me to collect most of the cast iron base/wood versions of their collector engine line.  Locomotive like engine components and tight machining tolerances are in a class of their own within the toy steam world...almost machinist built quality...", "2007-04-01 17:55:00", 0)

        IE(oC, 69, "Jensen", "Jensen #30", "1954", "IndianaRog", "http://www.indianarog.com", 1, "Representative of a 1954 Jensen #30 vertical boiler model incorporating a Jensen 25 solid cast iron engine, cast flywheel, plywood base, electrically heated.  Offered by Jensen in limited numbers in both metal based and wooden based versions...difficult to mfg. heater for vertical design boiler caused Jensen to eliminate from the production line...metal ones can still be found, wood based much rarer.  I used the correct boiler from a metal version, an orphan Jensen #25 engine and mounted both on a proper sized and beveled plywood base with a replica decal.  Identical to factory offering, but assembled by me.", "2007-04-01 17:55:00", 0)

        IE(oC, 70, "Jensen", "Jensen #40", "1960", "IndianaRog", "http://www.indianarog.com", 1, "Representative of a 1960 Jensen #40 vertical boiler model incorporating a Jensen 5 solid cast iron engine, cast flywheel, plywood base, electrically heated.  Like the #30, offered by Jensen in limited numbers in both metal based and wooden based versions...difficult to mfg. heater for vertical design boiler caused Jensen to eliminate from the production line...metal ones can still be found, wood based much rarer.  I used the correct boiler from a metal version, an orphan Jensen #5 engine and mounted both on a proper sized and beveled plywood base with a replica decal.  Identical to factory offering, but assembled by me.", "2007-04-01 17:55:00", 0)

        IE(oC, 71, "Jensen", "Jensen #51", "1977 - 1976", "IndianaRog", "http://www.indianarog.com", 1, "Representative of a 1977-1996 Jensen #51 power plant using a 1967 Jensen #50 as the core of the project (like Jensen built them...though boiler used predated actual Jensen #51's that used convex faced boiler vs. flat.), solid cast iron engine, cast flywheel, plywood base, AC/DC electric generation, electrical control panel/analog metering, functional feedwater pump and water tower, electrically heated.  perhaps my favorite engine in my entire collection.  Fewer than 300 Jensen #50's have ever been made and only 27 converted into Jensen #51 flagship, top of the line models.  Last made was 1996.  This example was my attempt to make a replica of the #51 using photos only as a guide.  Scrounging parts plus restoration took 10 months and was completed in Dec. 2006.  I am very pleased with the final outcome.  Extensive coverage of the conversion process is documented on my website.", "2007-04-01 17:55:00", 0)

        IE(oC, 72, "Jensen", "Jensen #55", "1948 - 1950", "IndianaRog", "http://www.indianarog.com", 1, "Solid cast iron engine, twin cylinders, cast flywheel, Stevensons reversing linkage, plywood base, electrically heated.  An early version of this model and a real workhorse that will self start and reverse on the fly.", "2007-04-01 17:55:00", 0)

        IE(oC, 73, "Jensen", "Jensen #95G", "1995", "IndianaRog", "http://www.indianarog.com", 1, "Collaborative effort by Jensen and Karsten Gintschel of Germany (turbine designer), utilized a high wattage Jensen 3"" boiler paired up with Karsten's CNC machined turbine and brass geared transmission, Jensen flywheel tethered to a modern Jensen #15 generator and lamp, plywood base, electrically heated.  An innovative entry in the rarified toy steam turbine world...it spools up with a most pleasing sound like a Harrier jet engine!!  This piece is numbered #3 and hand signed by Mr. Tom Jensen Jr., son of the founder.  The first 25 pieces released in Dec. 2005 were offered in the hand signed version.  15 months later a hand signed example is commanding 3X the going price of an otherwise identical piece.  These are all assembled by Mr. Jensen himself.", "2007-04-01 17:55:00", 0)

        IE(oC, 74, "Jensen", "Jensen #15", "1950 - 1960s", "IndianaRog", "http://www.indianarog.com", 1, "First offered in 1952 in both a stand alone version and as tethered to Jensen #10 and #20 engines, cast iron base, 3 part magnet construction, brass/nickeled lamp post, produced 3-6 volts AC at high rpms.  Later replaced with aluminum bases, but same magnet/armature and lamp. A favorite among Jensen collectors, this style was the third major type of generator offered by Jensen beginning with the horseshoe magnet style, single year 1951 round magnet and finally in 1952 to present...the 3 part magnet, with transition in the mid '80's to present of an aluminum base vs. cast iron seen here. ", "2007-04-01 17:55:00", 0)

        IE(oC, 75, "Jensen", "Jensen #100", "mid 1980s", "IndianaRog", "http://www.indianarog.com", 1, "5 diecast tools and a line shaft mounted on a plywood base...initially offered in blue painted plywood, but quickly changed to natural varnish like this example.  Sold up thru the mid 1980's.  Setup was offered as an accessory workshop to tether to many of Jensen's engines.  Tool design was derived from Langes of Denmark where Mr. Jensen emigrated from.   ", "2007-04-01 17:55:00", 0)

        IE(oC, 76, "Bing", "130-721(Traction Engine)", "1914", "Manxman", "", 1, "<a href='http://images2.fotopic.net/?iid=ymuzph&noresize=1&nostamp=1&quality=70'>See catalog page here</a>", "2007-04-01 20:27:00", 0)

        IE(oC, 77, "Bing", "Steam Roller", "circa 1910", "Manxman", "", 1, "", "2007-04-01 20:27:00", 0)

        IE(oC, 78, "Wells", "Traction Engine", "???", "Dauntless", "http://dauntless-steam-engines.webs.com/", 1, "", "2007-04-01 21:11:00", 0)

        IE(oC, 79, "Mamod", "SA1", "1983", "Mamodman123", "http://www.mamodsteam.tk/", 1, "Brass version, limited edition of 1,170 made.", "2007-04-02 08:10:00", 0)

        IE(oC, 80, "Mamod", "RS1", "1980 -1989", "Mamodman123", "http://www.mamodsteam.tk/", 1, "Locomotive set.", "2007-04-02 08:10:00", 0)

        IE(oC, 81, "Mamod", "SE3", "circa 1950s", "Lewis", "http://www.lewismamods.piczo.com ", 1, "", "2007-04-02 20:20:00", 0)

        IE(oC, 82, "Mamod", "SE2", " circa 1960s", "Lewis", "http://www.lewismamods.piczo.com", 1, "Actually owned by Lewis' uncle.", "2007-04-02 20:20:00", 900)

        IE(oC, 83, "Mamod", "SP2", "1991-1996", "Lewis", "http://www.lewismamods.piczo.com", 3, "", "2007-04-02 20:25:00", 0)

        IE(oC, 84, "Mamod", "SP2", "1991-1996", "Lewis", "http://www.lewismamods.piczo.com", 1, "", "2007-04-02 20:25:00", 0)

        IE(oC, 85, "Mamod", "ME1", "1958-1977", "Lewis", "http://www.lewismamods.piczo.com", 2, "", "2007-04-02 20:25:00", 0)

        IE(oC, 86, "Mamod", "MEC1", "1965-1979", "Lewis", "http://www.lewismamods.piczo.com", 4, "The MEC1 was introduced when Meccano requested Mamod to construct an engine specially designed to drive Meccano models, it was branded with the Meccano logo instead of the Mamod loco.  After Mamod's agreement with Meccano ended the model was rebranded the Mamod SP3 and a sight glass and whistle were added.  <br>Unusally the water plug on this example was drilled at the wrong end.", "2007-04-02 22:10:00", 0)

        IE(oC, 87, "Mamod", "SE2", "1937", "Mike (knowsnothing)", "http://www.mikes-steam-engines.co.uk", 1, "", "2007-04-03 08:30:00", 100)

        IE(oC, 88, "Maxwell Hemmens", "Birmingham Dribbler", "1970s+?", "Mike (knowsnothing)", "http://www.mikes-steam-engines.co.uk", 2, "Dribblers where made by a company called Maxwell Hemmens of Thorganby, England.", "2007-04-03 08:30:00", 0)

        IE(oC, 89, "Maxwell Hemmens", "Birmingham Dribbler", "1970s+?", "Mike (knowsnothing)", "http://www.mikes-steam-engines.co.uk", 2, "Dribblers where made by a company called Maxwell Hemmens of Thorganby, England.", "2007-04-03 08:30:00", 0)

        IE(oC, 90, "SEL", "1520 Minor", "1950s", "Roly Williams", "http://rolywilliams.com/sel_minor.html", 2, "Smaller version of the 'Standard' with no frame. The crankshaft passes through the firebox with the cylinder on one side and the flywheel on the other. Single wick meths burner. Base 88mm x 82mm.", "2007-04-06 09:15:00", 0)

        IE(oC, 91, "SEL", "1530 Junior", "1950s", "Roly Williams", "http://rolywilliams.com/sel_junior.html", 1, "A poor compromise between the 'Standard' and the 'Minor'. The cylinder is mounted on an aluminium bracket that looks like a temporary fix. Single wick meths burner. Base 106mm x 99mm.", "2007-04-06 09:15:00", 0)

        IE(oC, 92, "SEL", "1540 Standard", "1950s", "Roly Williams", "http://rolywilliams.com/sel_standard.html", 1, "Single cylinder, single acting, oscillating cylinder in a bakelite frame. Two wick meths burner. Base 122mm square.", "2007-04-06 09:15:00", 0)

        IE(oC, 93, "SEL", "1550 Major", "1950s", "Roly Williams", "http://rolywilliams.com/sel_major.html", 1, "Twin cylinder version of the 'Standard'. Base 154mm x 143mm.", "2007-04-06 09:15:00", 0)

        IE(oC, 94, "SEL", "1560 Marine", "1950s", "Roly Williams", "http://rolywilliams.com/sel_steam_launch_unit.html", 1, "Marine engine, designed to be mounted into a boat. The cylinder is much larger than the others in the SEL range and is quite powerful if supplied with a suitable boiler. This unit was supplied to Mamod for use in their ME3 marine engine.", "2007-04-06 09:15:00", 0)

        IE(oC, 95, "Mamod", "SR1", "1961", "Griffin", "", 1, "", "2007-04-06 09:25:00", 0)

        IE(oC, 96, "Mamod", "SR1", "1966", "Griffin", "", 1, "", "2007-04-06 09:25:00", 0)

        IE(oC, 97, "Mamod", "SR1A", "1972 - 1976", "Griffin", "", 1, "", "2007-04-06 09:25:00", 0)

        IE(oC, 98, "Mamod", "SR1A", "1968 - 1970", "Griffin", "", 1, "", "2007-04-06 09:25:00", 0)

        IE(oC, 99, "Mamod", "SW1", "1972 - 1976", "Griffin", "", 1, "", "2007-04-06 09:25:00", 0)

        IE(oC, 100, "Mamod", "SW1", "1979+", "Griffin", "", 1, "", "2007-04-06 09:25:00", 0)

        IE(oC, 101, "Mamod Accessories", "LW1", "1969 to 1978", "Griffin", "", 1, "", "2007-04-06 09:25:00", 0)

        IE(oC, 102, "Mamod Accessories", "OW1", "1969 to 1978", "Griffin", "", 1, "", "2007-04-06 09:25:00", 0)

        'IE oC, 103, "Mamod Accessories", "OW1", "1969 to 1978", "Griffin", "", 1, "", "2007-04-06 09:25:00"

        IE(oC, 104, "Bing", "130-605", "1930s", "IndianaRog", "http://www.indianarog.com", 1, "Stationaire Locomobile (overtype) approx. 1918 vintage.  Best guess is model #130/605<br>fully restored as received...added the little condensate bucket and a more correct looking chimney...has nicely machined main bearings...joy to run", "2007-04-06 09:45:00", 0)

        IE(oC, 105, "Mersey Model Co Ltd", "53R", "1930s", "IndianaRog", "http://www.indianarog.com", 1, "Reversing via unique lever/valve, single cylinder oscillator, built in lineshaft, oiler and utilized a 4 burner meths design that was inserted thru the bottom of the board...flame proof metal shield beneath to prevent scorching was added to this and later models...others are often found with severe charing of base wood from inserting blazing burners.  Factory unfortunately bombed out of business in WWII", "2007-04-06 09:45:00", 0)

        IE(oC, 106, "Bowman", "E101", "???", "IndianaRog", "http://www.indianarog.com", 1, "Bowman E101 (wood based vs. metal based M101), large chunky boiler 3"" x 6"" in size, flywheel weighing a full pound of brass, built in oiler, solid steel engine frame, gearing, exhaust lagged to a boiler stud and exhausts to chimney. <br>Nothing quite sounds like the machinegun cadence of a Bowman 101...Bowman's top of the line model with copious amounts of brass.", "2007-04-06 09:45:00", 0)

        IE(oC, 107, "Fleischmann", "122-3", "1961", "IndianaRog", "http://www.indianarog.com", 1, "Built 1961...for my 10th birthday!<br> This is the engine that got me hooked on toy steam.  Simple oscillator, Esbit fired, metal base, built in governor, whistle...but no throttle.  Boiler finished by a process called 'japaning'...a bluing of sorts.  Fleischmann stationary steam engines were taken over by Wilesco in the early '60's...Fleischmann was the last of the early Nurembourg toy steam builders...some of their features still carry on in the Wilesco line to this day.", "2007-04-06 09:45:00", 0)

        IE(oC, 108, "Stuart Turner", "Stuart Beam", "???", "IndianaRog", "http://www.indianarog.com", 1, "Stuart Models, England provide the castings to used to build this engine.<br>Stuart Beam with governor...machined by unknown craftsman in England...dating unknown. <br>just joined the Temple of Steam...fully functional upon receipt, done in partial paint scheme with some parts painted, some left bare cast iron.  Weighs 12 pounds, is 13"" tall, about the same long and 6 inches wide.  A jewel of an engine to watch cycle, especially at low rpms.", "2007-04-06 12:05:00", 0)

        IE(oC, 109, "Stuart Turner", "10H", "???", "IndianaRog", "http://www.indianarog.com", 1, "Model 10H, one of the smaller Stuarts.  Possible factory machined finished piece but actual builder and dating unknown...did come from England to me in present form.  About 6 inches in length...any of the Stuart machinist built models are a cut above any of the toy steam engines out there, but priced accordingly.  This one runs equally well on air or steam exhaust from a medium sized boiler.", "2007-04-06 12:05:00", 0)

        IE(oC, 110, "Wormar", "Trojan Model D", "???", "IndianaRog", "http://www.indianarog.com", 1, "Bowman of Dereham, Norfolk, England built Wormar engines. A complete wreck upon receipt, heavily restored including a meths burner crafted from a spent Mamod boiler...vertical boiler housed inside brass outer shroud.", "2007-04-06 12:05:00", 0)

        IE(oC, 111, "Karsten Gintschel", "1st Generation Oscillator (Prototype)", "late 1990s", "IndianaRog", "http://www.indianarog.com", 1, "Karsten's first oscillator design, no. 1 of 1 built, date unknown, but likely late 1990's. My first Karsten, procured in a trade with MooseMan...leading to many others from varied sources.  Characteristics of this prototype can be seen in Karsten's 2nd generation commercialized oscillator that followed.", "2007-04-06 12:05:00", 0)

        IE(oC, 112, "Karsten Gintschel", "2nd Generation Oscillator", "2000", "IndianaRog", "http://www.indianarog.com", 1, "Purchased directly from Karsten himself, this piece embodies many of the concepts tested in his prototype oscillator, except he ventured into a vertical boiler vs. his trademark ""ball"" style boiler.  Innovative alcohol reservoir built into wooden base, filled with a syringe...very smooth runner with stunning CNC work.  Nice to have the prototype AND commercial version of this his only oscillating engine...all rest were turbines.", "2007-04-06 12:05:00", 0)

        IE(oC, 113, "Karsten Gintschel", "Steamball", "2003 - 2004", "IndianaRog", "http://www.indianarog.com", 1, "Karsten's rendition of the Aeolipile, supposedly man's first version of a steam engine designed as a toy by the ancient Heron of Alexander.  This example is possibly Karsten's biggest commercial success.  Purchased in 2004 and probably made 2003-2004 as I had to order it.  Fun piece to operate and always engaging to anyone new to steam toys.", "2007-04-06 12:05:00", 0)

        IE(oC, 114, "Karsten Gintschel", "Turbine (1st Generation)", "late 1990s", "IndianaRog", "http://www.indianarog.com", 1, "This piece was one of just 15 made (another source says 30 made?).  Turbine blade rides on ball bearings and reaches incredibly fast rpms.  Ball boiler containing 15 cc of water will give a 4-5 minute run.  12 cc of denatured alcohol feed the burners beneath the ball...a common ratio of water to alcohol in all Karsten's ball style boilers.", "2007-04-06 12:55:00", 0)

        IE(oC, 115, "Karsten Gintschel", "Gate Turbine", "2000", "IndianaRog", "http://www.indianarog.com", 1, "Just one of 30 made and a personal favorite...built on a floating platform for a nice visual effect...kind of a sci fi looking design.", "2007-04-06 12:55:00", 0)

        IE(oC, 116, "Karsten Gintschel", "Ring Turbine", "late 1990s", "IndianaRog", "http://www.indianarog.com", 1, "This piece is serial number 40 out of 100 made.  Quite attractive with a formed drip pan beneath the turbine to catch condensate...a nice progression from the Steamball concept into a true turbine...a real screamer at high rpms.", "2007-04-06 12:55:00", 0)

        IE(oC, 117, "Karsten Gintschel", "Saxonia Turbine", "2005", "IndianaRog", "http://www.indianarog.com", 1, "Serial number 24 of an item still sold, mine acquired in 2005.  Innovative burner snuffing system can control heat to boiler incrementally.  Turbine can be opened up for better visibility under steam.  Fit and finish is superb.", "2007-04-06 12:55:00", 0)

        IE(oC, 118, "Karsten Gintschel", "V-6 Turbine Power Plant", "2000s", "IndianaRog", "http://www.indianarog.com", 1, "Serial number 8 of a piece still in production for commercial sale.  Good demonstration in miniature of electrical generation from a turbine...albeit the turbine is powering a very tiny generator...it works and demonstrates the principal.  An auxiliary motor accessory can be connected to this ""power station"" to further demonstrate power generation...I have the motor accessory though not pictured here...it is on my website.", "2007-04-06 12:55:00", 0)

        IE(oC, 119, "Karsten Gintschel", "Turbine Built for Jensen 95G", "1995", "IndianaRog", "http://www.indianarog.com", 1, "Collaborative design for Jensen Mfg. Company's Jensen model 95G. <br>Melding my two favorite manufacturers together...this is the most powerful turbine available to the toy steam marketplace today.  Powered by a 3 inch x 6 inch Jensen boiler, this turbine with it's brass geared transmission is capable of strongly lighting Jensen's #15 generator and lamp set.  The sound is fabulous, like a Harrier jet spooling up...an absolute favorite. <br> See the full engine <a href='../Jensen/Jensen_95G.htm'>here</a>.", "2007-04-06 12:55:00", 0)

        IE(oC, 120, "Mamod", "SL3", "???", "Sandy Hunter (sandman)", "http://www.freewebs.com/sandmansteamshack/index.htm", 2, "", "2007-04-06 13:08:00", 0)

        IE(oC, 121, "Mamod", "TE1", "1965", "Griffin", "", 1, "", "2007-04-06 13:11:00", 0)

        IE(oC, 122, "Mamod", "TE1A", "1972 - 1976", "Griffin", "", 1, "", "2007-04-06 13:11:00", 0)

        IE(oC, 123, "Mamod", "SA1", "1976", "Griffin", "", 1, "", "2007-04-06 13:11:00", 0)

        IE(oC, 124, "Mamod", "SA1", "1979", "Griffin", "", 1, "", "2007-04-06 13:11:00", 0)

        IE(oC, 125, "Jensen", "Jensen #55G", "2007", "Griffin", "", 1, "", "2007-04-06 13:16:00", 0)

        IE(oC, 126, "Hornby", "Rocket", "1970s", "Roly Williams", "http://rolywilliams.com/hornby_rocket.html", 1, "A large 3.5"" gauge engine. Gas fired with a refillable gas tank in the tender and a rather obtrusive valve on the footplate. Twin cylinder, double acting cylinders, driving the front wheels via gears, unlike the original. Overall length 410mm.", "2007-04-08 08:31:00", 0)

        IE(oC, 127, "Weeden", "903", "???", "Roly Williams", "http://rolywilliams.com/weeden_903.html", 1, "A simple single cylinder, single acting (despite visual appearance), oscillating cylinder. 110V electric heated. Base 186mm x 168mm.", "2007-04-08 08:31:00", 0)

        IE(oC, 128, "Wilesco", "D3", "2005", "Roly Williams", "http://rolywilliams.com/wilesco_D3.html", 1, "Wilesco's smallest and cheapest model. Brownie point for the environment - it uses recycled materials. Esbit fired; the firebox is made from an Agfa film container! Height 195mm.", "2007-04-08 08:31:00", 0)

        IE(oC, 129, "Wilesco", "D6", "1960s", "Roly Williams", "http://rolywilliams.com/wilesco_D6.html", 1, "Esbit fired. Height 214mm.", "2007-04-08 08:41:00", 0)

        IE(oC, 130, "Wilesco", "D16", "1970s", "Roly Williams", "http://rolywilliams.com/wilesco_D16.html", 1, "Restored by Roly Williams. Esbit fired. Height 310mm.", "2007-04-08 08:41:00", 0)

        IE(oC, 131, "Bowman", "M167", "???", "Sandy Hunter (sandman)", "http://www.freewebs.com/sandmansteamshack/index.htm", 2, "Bowman M167 with Repro chimney.", "2007-04-08 08:50:00", 0)

        IE(oC, 132, "Bowman", "M175", "???", "Sandy Hunter (sandman)", "http://www.freewebs.com/sandmansteamshack/index.htm", 1, "", "2007-04-08 08:50:00", 0)

        IE(oC, 133, "Mamod", "SE1", "???", "Sandy Hunter (sandman)", "http://www.freewebs.com/sandmansteamshack/index.htm", 2, "", "2007-04-08 08:50:00", 200)

        IE(oC, 134, "John Haining", "Traction Engine", "???", "seven.mpd", "", 1, "My pride & joy, so far unnamed 2"" Coal fired Agricultural Traction Engine by John Haining, the plans were published in model Engineer in 1969 the engine was based on a Durham & N.Yorkshire engine and was completed in 1987 by I.S (whoever this was) I have had the engine two weeks intend to clean it and use in the summer then strip and repaint though the winter", "2007-04-08 08:55:00", 0)

        IE(oC, 135, "Hornby", "Rocket", "1970s", "seven.mpd", "", 1, "3.5in Gas fired  Stevenson's Rocket  produced by Hornby in the late seventies. I got this in a very poor and incomplete condition in Jan 2007 since then I have restored it, making some parts and tracking down others, it is now ready to 'fire'  ", "2007-04-08 08:55:00", 0)

        IE(oC, 136, "Empire", "B42", "1926 - 1930", "IndianaRog", "http://www.indianarog.com", 1, "Model B-42, twin cylinder, twin boiler built approx. 1926-1930. The rarest Empire toy steam engine based on the princely price of $25 USD during the depression years.  Assumption is that this was a premium toy and few were mfg. as they are very rarely seen on eBay or elsewhere.  Solid cast iron base, brass engine components and nickeled brass boilers.  Rivals early Jensens for robustness.  Heated electrically.", "2007-04-08 09:01:00", 0)

        IE(oC, 137, "Empire", "B31", "1921 - 1931", "IndianaRog", "http://www.indianarog.com", 1, "Model B-31, vertical style boiler, built approx. 1921-1931. The 2nd most plentiful of the cast iron Empire toy steam engines based on the 10 year production period and freqency of seeing them on eBay.  Solid cast iron base, brass engine components and nickeled brass boiler.  Actually just a vertical version of the most popular B-30 horizontal model.  Rivals early Jensens for robustness.  Heated electrically.", "2007-04-08 09:01:00", 0)

        IE(oC, 138, "Empire", "B30", "1921 - 1941", "IndianaRog", "http://www.indianarog.com", 1, "Model B-30, horizontal style boiler, built approx. 1921-1941. The most plentiful of the cast iron Empire toy steam engines based on the 20 year production run and freqency of seeing them on eBay, where they come up for sale weekly.  Solid cast iron base, brass engine components and nickeled brass boiler.  Virtually the same engine as the B-31 which differs only by orienting the boiler vertically. Rivals early Jensens for robustness.  Heated electrically.", "2007-04-08 09:01:00", 0)

        IE(oC, 139, "Empire", "B35 Turbine", "1925 - 1940", "IndianaRog", "http://www.indianarog.com", 1, "Model B-35, Turbine steam engine mounted on horizontal style boiler, built approx. 1925-1940. The 3rd most plentiful of the cast iron Empire toy steam engines despite a 15 year production period...they come up occasionally on eBay, but not often.   Solid cast iron base, brass engine components, nickeled brass boiler and tinned turbine fan. Most examples have a 1/4 mesh chicken wire over the turbine, mine seems to have lost it in it's travels. An early turbine example when turbines were fairly rare for the toy steam world. Rivals early Jensens for robustness, though it would take Jensen about 75 years more to come up with their model 95G turbine introduced in 1995.  Empire got their early but Jensen wins in the looks and functionality dept. Heated electrically.", "2007-04-08 09:01:00", 0)

        IE(oC, 140, "Wilesco", "D36", "1985", "IndianaRog", "http://www.indianarog.com", 1, "Model D36, ""Old Smokey"" Steam Roller...built approx. 1985. A toy every boy must have from age 9-99.  Wilesco does a good job of replicating the ""look"" of the steam rollers old without making them so expensive only collectors could afford them.  This example was unfired until Nov. 2006 until, at the urging of a young steamer I gave it a go.  It will run in a stationary position or roll forward at a scale like pace with the engagement of a lever.  A really fun steam engine sold to this day in the exact same design, though I think it's called the D365 now and another version is sold in brass trim. ", "2007-04-08 09:01:00", 0)

        IE(oC, 141, "Wilesco", "D455", "2005", "IndianaRog", "http://www.indianarog.com", 1, "Model D455, Vertical Steam Engine.  Built approx. 2005. Like the Old Smokey Roller...this is another engaging engine made by Wilesco.  Formally sold as the D45, it got the extra digit when another version came out in brass trim.  It generates high RPM's and being a vertical design is a bit different when most of my collection as horizontal boilers.  Like the Old Smokey, this Wilesco is fired with Esbit fuel tablets OR for a bit more umph, a denatured alcohol (meths) burner will make it really fly.", "2007-04-08 09:01:00", 0)

        IE(oC, 142, "Steamco", "STC-04", "2005", "IndianaRog", "http://www.indianarog.com", 1, "One of two lovely designs by a two brother team that is Steamco of Australia.  This one is a classy looking overtype with lots of brass and copper accents...beautifully executed.  One of the few engines in my collection I have not fired given it's beauty, but one of these days I will do it.  It runs on Esbit tablets for fuel.", "2007-04-08 09:01:00", 0)

        IE(oC, 143, "Wilesco", "D430 (Locomobile)", "2006", "Simon King (MTA)", "www.freewebs.com/simonscollections", 1, "", "2007-04-08 22:35:00", 0)

        IE(oC, 144, "Wilesco", "D365 (Steam Roller)", "2005", "Simon King (MTA)", "www.freewebs.com/simonscollections", 1, "", "2007-04-08 22:35:00", 0)

        IE(oC, 145, "Wilesco", "D141", "2006", "Simon King (MTA)", "www.freewebs.com/simonscollections", 1, "Biggest stationary in terms of L X W X H Wilesco produce.", "2007-04-08 22:35:00", 0)

        IE(oC, 146, "Doll", "Overhead Engine", "???", "John Chapman", "http://www.steamtoys.co.uk", 1, "", "2007-04-08 22:35:00", 0)

        IE(oC, 147, "Marklin", "4105", "pre 1929", "John Chapman", "http://www.steamtoys.co.uk", 1, "", "2007-04-08 22:35:00", 0)

        IE(oC, 148, "Unknown", "Unknown #1 Can any one help", "???", "John Chapman", "http://www.steamtoys.co.uk", 1, "This engine is a complete mystery. It is 9½ inches (24cm) tall and it has no maker's marks of any kind on it anywhere.  There is a photograph of one of these engines in Basil Harley's book ""Toyshop Steam"" (colour plate number 5). Unfortunately there is no information on it, the caption, merely states that the engine ""looks English""", "2007-04-08 22:35:00", 0)

        IE(oC, 149, "Crescent Toys", "#1", "1947", "John Chapman", "http://www.steamtoys.co.uk", 1, "The Crescent Horizontal Engine No.1 was Introduced in 1947. These engines were manufactured for Crescent Toys by C K Matsutoko of Japan.   The engine was not a commercial success, although cheap these engines were made from very thin, lightweight materials. There were also questions over the design of the burner which had a combined filler tube and handle. The burner was prone to catching fire and also tended to set the users hand alight! Only about 1000 were made, production ceasing in 1948.", "2007-04-08 22:35:00", 0)

        IE(oC, 150, "Burnac", "Vulcan", "1946 - 1949", "John Chapman", "http://www.steamtoys.co.uk", 1, "Made in England between 1946 and 1949 by Burnac Ltd of Burslem, Stoke-on-Trent.", "2007-04-08 22:35:00", 0)

        IE(oC, 151, "Mamod", "MM1", "???", "Simon King (MTA)", "www.freewebs.com/simonscollections", 1, "non-original flywheel fitted, reproduction one wick burner fitted, decals on BOTH sides of the firebox.", "2007-04-09 15:35:00", 0)

        IE(oC, 152, "Mamod", "SE3", "???", "Simon King (MTA)", "www.freewebs.com/simonscollections", 1, "", "2007-04-09 15:35:00", 0)

        IE(oC, 153, "Mamod", "SR1A", "1976", "Simon King (MTA)", "www.freewebs.com/simonscollections", 1, "", "2007-04-09 15:35:00", 0)

        IE(oC, 154, "Mamod", "TE1A", "2002", "Simon King (MTA)", "www.freewebs.com/simonscollections", 1, "", "2007-04-09 15:35:00", 0)

        IE(oC, 155, "MSS", "32mm Welsh Green 0-4-0T", "2005", "Simon King (MTA)", "www.freewebs.com/simonscollections", 1, "Lining and nameplates are non original, also the engine is currently undergoing detailing so it looks more like a narrow gauge engine.", "2007-04-09 15:35:00", 0)

        IE(oC, 156, "Mamod Accessories", "WAT", "2004", "Simon King (MTA)", "www.freewebs.com/simonscollections", 1, "Hubcaps are that off the Mamod mobile range, and not the black type as shown on the box.", "2007-04-09 15:35:00", 0)

        IE(oC, 157, "Bohm", "Sterling Engine", "2005", "IndianaRog", "http://www.indianarog.com", 1, "Model: twin flywheel, all brass and wood...made 2005.  ike the HOG, another Stirling engine from Germany, using the Stirling principle of motion generation from a simple flame.  NO water, NO steam...but visually a beauty operating or standing still.  Another modern rendition of the Stirling concept available on eBay or toy steam online retailers..", "2007-04-10 11:25:00", 0)

        IE(oC, 158, "Wiggers", "STIWI1 Sterling Engine", "2005", "IndianaRog", "http://www.indianarog.com", 1, "Germany seems to be THE source for modern Stirling engine examples.  This is my third from that country and if one searches on Google for the words Wiggers Stirling...you will find a company with a huge array of Stirling designs from the simplest (which this is)...to the quite elaborate and ornate.  Probably the prettiest Stirlings out there in my opinion.  Wiggers also retails the HOG line of Stirlings of the type shown in another image here.", "2007-04-10 11:25:00", 0)

        IE(oC, 159, "PM Research", "Flame Licker", "2005", "IndianaRog", "http://www.indianarog.com", 1, "NOT a steam engine (no water), NOT a Stirling (flame yes, but different principle of operation).  This chunky model is beautifully made by PM Research and operates off a strategically placed flame that aligns with a port in the cylinder wall.  With each stroke of the piston, a small hatch opens and closes on that cylinder wall letting the flame get sucked into the cylinder...closed off again that heated air expands and pushes piston only to repeat the cycle.  Very lovely thumping sound when operating and a visual delight as well.  It is one of my engines I like to run outdoors on a cold nite in the dark...looks a bit like you are staring into a blast furnace each time the flame gets sucked into the cylinder.", "2007-04-10 11:25:00", 0)

        IE(oC, 160, "HOG", "Mikro-Stirling engine", "2005", "IndianaRog", "http://www.indianarog.com", 1, "Lovely detail and a stunning runner.  HOG is one of the primary makers of modern Sterling engines and they utilize a Beam engine design that runs at incredible rpm...so fast it is but a blur while it runs almost silently off a flame the size of a match.  Thes can be found on eBay and popular online steam engine retailers...though there is no steam and no water used...just a flame.", "2007-04-10 11:25:00", 0)

        IE(oC, 161, "Cyldon", "13-3", "circa 1946", "John Chapman", "http://www.steamtoys.co.uk", 1, "", "2007-04-11 20:40:00", 0)

        IE(oC, 162, "Cyldon", "13-4", "circa 1946", "John Chapman", "http://www.steamtoys.co.uk", 1, "", "2007-04-11 20:40:00", 0)

        IE(oC, 163, "Mersey Model Co Ltd", "52", "circa 1940", "John Chapman", "http://www.steamtoys.co.uk", 1, "", "2007-04-11 20:40:00", 0)

        IE(oC, 164, "Mersey Model Co Ltd", "51", "circa 1940", "John Chapman", "http://www.steamtoys.co.uk", 1, "", "2007-04-11 20:40:00", 0)

        IE(oC, 165, "Latimer Productions", "Plane L5", "circa 1950", "John Chapman", "http://www.steamtoys.co.uk", 1, "", "2007-04-11 20:40:00", 0)

        IE(oC, 166, "Bing", "130-812", "circa 1914", "Roly Williams", "http://rolywilliams.com/bing_vertical.html", 2, "A simple single cylinder, single acting oscillating cylinder vertical boilered engine. Meths fired with a twin wick burner. Fully restored by Roly Williams.", "2007-04-14 22:41:00", 0)

        IE(oC, 167, "Bing", "130-466", "circa 1915", "Roly Williams", "http://rolywilliams.com/bing_horizontal.html", 2, "A large horizontal boiler, single cylinder, double acting slide valve with slip eccentric reversing. The burner is missing but it would probably have been a multiple wick type meths burner. Note the weighted safety valve.  The base paintwork and lithography appear to be original. The rest has been restored by Roly Williams.", "2007-04-14 22:41:00", 0)

        IE(oC, 168, "Bowman", "234", "circa 1930 - 1935", "Roly Williams", "http://rolywilliams.com/bowman_234.htm", 1, "This is the top of the range of Bowmans locos. The tender carries the number LNER 4472, which was the number carried by LNER's Flying Scotsman. The number is about the only similarity with the famous loco. When I bought this engine I was told it was from c1948, but I have since been told that the plain con rods date it much earlier.", "2007-04-14 22:45:00", 0)

        IE(oC, 169, "Mamod", "SR1A", "1967", "Spokesman", "http://spokessmann.tripod.com/index.html", 1, "1967 SR1a has the rare straight control lever. Restored 2007", "2007-04-15 09:35:00", 0)

        IE(oC, 170, "Mamod", "TE1A", "1967", "Spokesman", "http://spokessmann.tripod.com/index.html", 1, "1967 TE1a has the rare straigt lever. Restored 2006", "2007-04-15 09:35:00", 0)

        IE(oC, 171, "Mamod", "SR1", "1961", "Spokesman", "http://spokessmann.tripod.com/index.html", 1, "1961 roller is a nut and bolt version", "2007-04-15 09:35:00", 0)

        IE(oC, 172, "Mamod", "TE1", "1963", "Spokesman", "http://spokessmann.tripod.com/index.html", 1, "1963 TE1 is a nut and bolt version", "2007-04-15 09:42:00", 0)

        IE(oC, 173, "Bowman", "M122", "late 1920s to early 1930s", "Spokesman", "http://spokessmann.tripod.com/index.html", 1, "M122 was restored 2007", "2007-04-15 09:42:00", 0)

        IE(oC, 174, "Bowman", "M140", "late 1920s to early 1930s", "Spokesman", "http://spokessmann.tripod.com/index.html", 1, "M140 was restored 2007", "2007-04-15 09:42:00", 0)

        IE(oC, 175, "Mamod", "SW1", "1998", "Spokesman", "http://spokessmann.tripod.com/index.html", 1, "Blue SW1 - solid fuel", "2007-04-15 09:42:00", 0)

        IE(oC, 176, "Mamod", "SW1", "1973", "Spokesman", "http://spokessmann.tripod.com/index.html", 1, "Green SW1 meths fuelled", "2007-04-15 09:47:00", 0)

        IE(oC, 177, "Mamod", "SE2", "1948", "Spokesman", "http://spokessmann.tripod.com/index.html", 1, "1948 SE2 has the rare brass engine frame.", "2007-04-15 09:47:00", 400)

        IE(oC, 178, "Mamod", "SE1", "1954", "Spokesman", "http://spokessmann.tripod.com/index.html", 1, "1954 SE1 is unsteamed", "2007-04-15 09:47:00", 600)

        IE(oC, 179, "Mamod", "SE4", "1937", "Spokesman", "http://spokessmann.tripod.com/index.html", 2, "1937 SE4 with lineshaft", "2008-10-10 18:47:00", 0)

        IE(oC, 180, "Bowmans of Luton", "PW201", "1946-1950", "Spokesman", "http://spokessmann.tripod.com/index.html", 1, "", "2007-04-15 09:47:00", 0)

        IE(oC, 181, "Mamod", "MM1", "1954", "Spokesman", "http://spokessmann.tripod.com/index.html", 1, "", "2007-04-15 09:47:00", 0)

        IE(oC, 182, "Mamod", "MM2", "1960", "Spokesman", "http://spokessmann.tripod.com/index.html", 1, "", "2007-04-15 09:47:00", 0)

        IE(oC, 183, "Mamod", "MM2", "1960", "Spokesman", "http://spokessmann.tripod.com/index.html", 1, "", "2007-04-15 09:47:00", 0)

        IE(oC, 184, "Mamod", "SE3", "1969", "Spokesman", "http://spokessmann.tripod.com/index.html", 1, "1969 Mamod SE3 G&G", "2007-04-15 09:47:00", 0)

        IE(oC, 185, "Wilesco", "Traktor", "1991", "Spokesman", "http://spokessmann.tripod.com/index.html", 1, "", "2007-04-15 10:00:00", 0)

        IE(oC, 186, "Bowman", "M135", "late 1920s to early 1930s", "Spokesman", "http://spokessmann.tripod.com/index.html", 1, "M135 with Dynamo", "2007-04-15 10:00:00", 0)

        IE(oC, 187, "Kookaburra", "001 (Overtype)", "2006", "Tony Muir (tmuir)", "http://www.freewebs.com/ozsteam/index.htm", 2, "<div><strong>Kookaburra</strong></div> <div>Model&nbsp;001 Overtype</div> <div>Currently in Production</div> <div>Made in Australia by &lsquo;The Kookaburra Steam Engine Company&rsquo;</div>" & "<div>Web address<span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span><a href='http://www.kookasteam.com/index.html'>http://www.kookasteam.com/index.html</a></div> <p><span>They are soon to make a mill engine and traction engine.</span></p> <p><span>Each engine produced has its own serial number engraved on the engine and the base on a brass plaque.</span></p> <p><span>More of a steam model than a steam toy</span></p> <div>&nbsp;</div> <div>Engine Specs</div> <div><strong>TECHNICAL SPECIFICATIONS</strong></div> <ul type='disc'> <li><span>Weight - approx. 2kgs. (4 1/2 lb.)</span></li> <li><span>Size - approx. L-210mm. (8 1/2in.) W-160mm (61/4in.) H-200mm. (73/4in.)</span></li> <li><span>High level of detail in Engine Casting &amp; Stand</span></li> <li>Brass Cylinder &amp; Piston</li> <li><span>Ope" & "rates on Methylated Spirits, Ethanol or Wood Alcohol Only</span></li> <li><span>Normal operating pressure 20psi. (138kpa.)</span></li> <li><span>Boiler pressure tested to 120psi. (827kpa)</span></li> </ul> <p>&nbsp;</p>", "2007-04-01 18:40:00", 0)

        IE(oC, 188, "Steamco", "STC-01", "Still in production", "Tony Muir (tmuir)", "http://www.freewebs.com/ozsteam/index.htm", 2, "<div><strong>Model STC-01</strong></div> <p><span>Currently still in production</span></p> <div>Made in Australia by Steamco</div> <div>Web address<span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href='http://www.steamcoengines.com.au/'>http://www.steamcoengines.com.au/</a></span></div> <p><span>They also make an overtype engine and used to make a marine engine and a boat fitted with the engine.</span></p> <div><strong>Model STC-01&nbsp;Stationary Steam Engine Specifications</strong></div> <ul> <li>Engine Single Acting Oscillating type</li> <li><span>Brass Boiler</span> Silver Soldered</li> <li>Cylinder Bore 8 mm</li> <li>Cylinder Stroke 19 mm</li> <li>Flywheel Diameter 60 mm</li> <li>Fuel Dry Spirit Tablets</li> <li>Height 165 mm x Length 195 mm x Width 150 mm&nbsp;</li> </ul> <p>&nbsp;</p> <p>&nbsp;</p>", "2007-04-15 18:40:00", 0)

        IE(oC, 189, "Gakken", "Steam Car", "2006", "Manxman", "", 1, "", "2007-04-01 20:27:00", 0)
        IE(oC, 190, "Cranko", "Steam Roller", "late 1940s to 1956", "Manxman", "", 1, "", "2007-04-01 20:27:00", 0)

        IE(oC, 191, "Mamod Accessories", "SP Power Press", "1979+", "Lewis", "http://www.lewismamods.piczo.com", 1, "", "2007-04-17 18:05:00", 0)

        IE(oC, 192, "Mamod Accessories", "SP Lineshaft", "1979+", "Lewis", "http://www.lewismamods.piczo.com", 1, "", "2007-04-17 18:05:00", 0)

        IE(oC, 193, "Mamod Accessories", "SP Power Hammer", "1979+", "Lewis", "http://www.lewismamods.piczo.com", 1, "", "2007-04-17 18:05:00", 0)

        IE(oC, 194, "Mamod Accessories", "SP Grinding Machine", "1979+", "Lewis", "http://www.lewismamods.piczo.com", 1, "", "2007-04-17 18:05:00", 0)

        IE(oC, 195, "Mamod Accessories", "SE Workshop", "1979+", "Lewis", "http://www.lewismamods.piczo.com", 1, "", "2007-04-17 18:05:00", 0)

        IE(oC, 196, "SEL", "1540 Standard", "1950s", "Lewis", "http://www.lewismamods.piczo.com", 1, "", "2007-04-17 18:05:00", 0)

        IE(oC, 197, "Mamod", "SR1A", "2005", "Lewis", "http://www.lewismamods.piczo.com", 1, "", "2007-04-17 18:05:00", 0)

        IE(oC, 198, "Mamod", "MM2", "1970s", "Lewis", "http://www.lewismamods.piczo.com", 1, "", "2007-04-17 18:05:00", 0)

        IE(oC, 199, "David Auld", "Steam Roller", "1966 to 1989", "Manxman", "", 8, "Pictures of this engine were taken by Tony Muir (tmuir) who sourced the engine in Australia on Manxman's behalf. ", "2007-04-18 21:40:00", 0)

        IE(oC, 200, "Liney Machine", "RV-1", "2004", "IndianaRog", "http://www.indianarog.com", 1, "Design by machinist Lance Liney, uses oscillatory rotating valves and twin single action cylinders.  Small piece, just 3"" x 4"" footprint.  Cylinders are unique in that they are phased exactly the same, not staggered as in most twin cylinder engines.", "2007-04-21 10:35:00", 0)

        IE(oC, 201, "Liney Machine", "Thimble", "2006", "IndianaRog", "http://www.indianarog.com", 1, "Design by machinist Lance Liney, uses a novel ""blow by"" style piston .30 inches in diameter.  Instead of having valves, the piston tips sideways on the return stroke allowing the steam to blow by the piston.  Flywheel is just 1-1/8 inches in diameter.  Engine all brass except aluminum/wood pedestal.  Incredibly high rpms, will run quite fast on just human breath. ", "2007-04-21 10:35:00", 0)

        IE(oC, 202, "Mamod", "MM2", "1953", "Lewis", "http://www.lewismamods.piczo.com", 2, "Engine was so badly rusting away that a respray was done.", "2007-04-21 14:35:00", 0)

        IE(oC, 203, "Mamod", "ME1", "1958", "Spokesman", "http://spokessmann.tripod.com/index.html", 1, "Mint ME1 marine engine dating from 1958, with early brass vap lamp and engine oiler.", "2007-04-29 09:35:00", 0)

        IE(oC, 204, "Hobbies", "Polisher", "1936", "Spokesman", "http://spokessmann.tripod.com/index.html", 1, "Hobbies dating from around 1936. Flatbase tool finished in darker Hobbies green, with oiling holes.", "2007-04-29 09:35:00", 0)

        IE(oC, 205, "Mamod Accessories", "Lineshaft", "late 50s to early 60s", "Spokesman", "http://spokessmann.tripod.com/index.html", 1, "Lineshaft with large rectangular decal, dating from late 50s/early 1960s. Screw construction.", "2007-04-29 09:35:00", 0)

        IE(oC, 206, "Mamod Accessories", "Grinder", "1952", "Spokesman", "http://spokessmann.tripod.com/index.html", 1, "Grinder, dating from 1952 - the original version with oil holes and mixed grinding wheels. Boxed.", "2007-04-29 09:35:00", 0)

        IE(oC, 207, "Mamod Accessories", "Polisher", "mid 1950s", "Spokesman", "http://spokessmann.tripod.com/index.html", 1, "Polisher from mid 1950s with oil holes. Boxed", "2007-04-29 09:35:00", 0)

        IE(oC, 208, "Mamod Accessories", "Power Hammer", "1948-53", "Spokesman", "http://spokessmann.tripod.com/index.html", 1, "Power Hammer dating from 1948-53, with cast iron pedestal and hot brass stamped flywheel.", "2007-04-29 09:35:00", 0)

        IE(oC, 209, "Mamod Accessories", "Power Press", "1950s", "Spokesman", "http://spokessmann.tripod.com/index.html", 1, "Power presses from mid 1950S (early unclipped mazak flywheel and oiling holes) and 1948-53 power press with hot brass stamped flywheel, base decal and oiling holes and cast iron frame. Plunger type end.", "2007-04-29 09:35:00", 0)

        IE(oC, 210, "Wilesco", "D3", "2006", "Lewis", "http://www.lewismamods.piczo.com", 3, "", "2007-04-29 9:52:00", 0)

        IE(oC, 211, "Mamod", "SL6", "1989", "Roly Williams", "http://rolywilliams.com/mamod_sl6.html", 2, "A limited edition version of the SL1 made for the Golden Jubilee year.", "2007-04-29 22:01:00", 0)

        IE(oC, 212, "Mamod", "ME3", "1958-1977", "Roly Williams", "http://rolywilliams.com/mamod_me3.html", 2, "Marine engine fitted with the SEL 1560 engine unit.", "2007-04-29 22:01:00", 0)

        IE(oC, 213, "MSS", "Golden Jubilee Loco", "16th July 2002", "Graham-Jilly", "", 2, "Limited edition number J011 is molded on the smokebox.", "2007-05-01 20:15:00", 0)

        IE(oC, 214, "Mamod", "RS2", "???", "Graham-Jilly", "", 2, "The RS2 railway set contains the SL2 locomotive.", "2007-05-01 20:15:00", 0)

        IE(oC, 215, "Mamod", "TE1V", "2006", "Wyvern", "", 2, "This is number 14/100 of the special edition TE1V produced by mamod for forest classics.  The model is pictured with rubber tyres (bought separately) and without the additional black canopy or brass chimney cowl supplied.    The model is the first piston valve model and features the new mamod piston valve steam engine and a new boiler.   The boiler features superheating via 2 tubes which take steam from the boiler and circulate it through the burner and back in to the boiler.   I have been informed that this was changed to a coil configuration in the later official ""challenger""  and ""centurion"" models.   The model is much more controllable and has far more torque than a TE1A.   It is possible to slow the model down to a crawl.   By far my most used engine.", "2007-05-03 23:51:00", 0)

        IE(oC, 216, "Bassett Lowke", "BL99002 ", "2000", "Wyvern", "", 3, "Bassett lowke 2-6-0 number 514/750 BL99002 produced around the year 2000.    The model was bought unfired in 2006.   Features a displacement lubricator accessed via the removable smokebox and a vapourising spirit lamp burner.   Although recommended to operate on a minimum track radius of  30"" or so we found mamod track to be too tight so we built a new running track to 46"".", "2007-05-05 13:41:00", 0)

        IE(oC, 217, "Wilesco", "Old Smokey", "2006", "Wyvern", "", 1, "Wilesco 'Old Smokey' steam roller with homemade rubber tyres to aid grip.   Bought second hand from ebay in 2006. ", "2007-05-05 13:52:00", 0)

        IE(oC, 218, "Bowman", "300", "circa 1930", "Odilon Marcenaro (MooseMan)", "http://www.MooseMan.org.uk/", 1, "As found, good running order. Bowman’s 'true O gauge' engine.", "2007-05-06 16:01:00", 0)

        IE(oC, 219, "EPD", "Stationary Engine", "1946-1953", "Odilon Marcenaro (MooseMan)", "http://www.MooseMan.org.uk/", 1, "Eberhard Pässler, Dresden. Made between ‘45 and ‘63 in the former DDR. Stainless steel boiler and cast alloy slide valve engine.", "2007-05-06 16:01:00", 0)

        IE(oC, 220, "Bowmans of Luton", "PW203", "1946-50", "Spokesman", "http://spokessmann.tripod.com/index.html", 3, "Dates from 1946-50, boxed and and with transfer decal on baseplate. Burner is the rounded corner type reservoir with cross slitted burner arms instead of the single longitudinal burner slots.", "2007-05-14 20:55:00", 0)

        IE(oC, 221, "Wells", "Traction Engine", "circa 1972-1980s", "Manxman", "", 1, "", "2007-05-23 20:57:00", 0)

        IE(oC, 222, "Wells", "Traction Engine", "circa 1972-1980s", "Manxman", "", 1, "", "2007-05-23 20:57:00", 0)

        IE(oC, 223, "Wells", "Traction Engine", "circa 1972-1980s", "Manxman", "", 1, "", "2007-05-23 20:57:00", 0)

        IE(oC, 224, "Mamod", "SE2", "1958", "Lewis", "http://www.lewismamods.piczo.com", 2, "", "2007-06-13 22:20:00", 800)

        IE(oC, 225, "SEL", "SEL Fan", "", "Lewis", "http://www.lewismamods.piczo.com", 1, "", "2007-06-13 22:20:00", 0)

        IE(oC, 226, "Jensen", "Jensen #75", "1960s", "James Chantry", "www.mamods.piczo.com", 3, "Administrator of the Mamod and Other Steam Forum <a href='http://www.mamodforums.co.uk'>www.mamodforums.co.uk</a> <br>This is the highest engine in the toy range of Jensen. It features working Stevenson's valve linkage. This model is Esbit fired, and this particular model features a copper clad type firebox, before the new ""pink"" paint was introduced. ", "2007-06-13 22:21:00", 0)

        IE(oC, 227, "Jensen", "Jensen #65", "1970s approx", "James Chantry", "www.mamods.piczo.com", 2, "Administrator of the Mamod and Other Steam Forum <a href='http://www.mamodforums.co.uk'>www.mamodforums.co.uk</a><br>This model #65 is the sort of middle of the line of model Jensens. It features a slide valve mechanism, and runs on Esbit.", "2007-06-13 22:22:00", 0)

        IE(oC, 228, "Jensen", "Jensen #70", "1960 to 1970s approx", "James Chantry", "www.mamods.piczo.com", 1, "Administrator of the Mamod and Other Steam Forum <a href='http://www.mamodforums.co.uk'>www.mamodforums.co.uk</a><br>The Jensen #70 is the fastest running engine in the Jensen range. Electrically heated and featuring a strangely mounted piston/cylinder assembly, this is one good looking engine! Mine is not in the best of condition, as I picked it up off ebay.com for £16", "2007-06-13 22:23:00", 0)

        IE(oC, 229, "Jensen", "Jensen #76", "1960 to 1970s approx", "James Chantry", "www.mamods.piczo.com", 2, "Administrator of the Mamod and Other Steam Forum <a href='http://www.mamodforums.co.uk'>www.mamodforums.co.uk</a><br>The Jensen #76 is a cute little engine. Very strong for its size, and a very compact little engine. It features alot of things for a near bottom of the range engine, like whistle and regulator. This one was bought by me from my good friend IndianaRog ", "2007-06-13 22:24:00", 0)

        IE(oC, 230, "Mamod", "TE1A (Old Glory)", "14th September 1999", "James Chantry", "www.mamods.piczo.com", 1, "Administrator of the Mamod and Other Steam Forum <a href='http://www.mamodforums.co.uk'>www.mamodforums.co.uk</a><br>This is a special editon of 250 worldwide, produced for Old Glory magazine. This engine is in near mint condition.", "2007-06-13 22:24:00", 0)

        'IE oC, 231, "Mamod", "SE1", "Early 1946", "James Chantry", "www.mamods.piczo.com", 1, "Administrator of the Mamod and Other Steam Forum <a href='http://www.mamodforums.co.uk'>www.mamodforums.co.uk</a><br>This Mamod was made for a few months in early 1946, and it revived from pre war with only one difference- exhaust to chimney. This engine is extremely rare and is in mint original condition.", "2007-06-13 22:25:00"

        'IE oC, 232, "Mamod", "Showmans Engine", "17th February 2006", "James Chantry", "www.mamods.piczo.com", 1, "Administrator of the Mamod and Other Steam Forum <a href='http://www.mamodforums.co.uk'>www.mamodforums.co.uk</a><br>This Mamod Showmans engine was bought brand new by me in 2006, and it features a working dynamo and lights! This is one of the best newer models produced by Mamod.", "2007-06-13 22:26:00"

        IE(oC, 233, "Mamod", "SE1", "1953", "Mamodman123", "http://www.mamodsteam.tk/", 1, "", "2007-06-16 12:10:00", 500)

        IE(oC, 234, "Mamod", "SR1", "Circa 1962", "Mamodman123", "http://www.mamodsteam.tk/", 1, "Nut and bolt construction", "2007-06-16 12:11:00", 0)

        IE(oC, 235, "Mamod", "SE4", "1937-1939", "Mamodman123", "http://www.mamodsteam.tk/", 1, "Finally completed with decal and burner.", "2007-06-16 12:13:00", 0)

        IE(oC, 236, "Mamod", "SP2", "6th Oct 2006", "Mamodman123", "http://www.mamodsteam.tk/", 1, "", "2007-06-16 12:14:00", 0)

        IE(oC, 237, "Mamod", "SL6", "1989", "Graham-Jilly", "http://www.freewebs.com/aclr", 1, "This is number 752 of 1000 made.", "2007-08-23 07:46:00", 0)

        IE(oC, 238, "Mamod", "SL4", "???", "Graham-Jilly", "http://www.freewebs.com/aclr", 1, "", "2007-08-23 08:25:00", 0)

        IE(oC, 239, "Steamco", "STC-01", "circa 2000", "Graham-Jilly", "http://www.freewebs.com/aclr", 1, "Made in Melbourne Australia ", "2007-08-23 08:25:00", 0)

        IE(oC, 240, "Mamod", "ME2", "1958", "Spokesman", "http://spokessmann.tripod.com/index.html", 3, "Mamod ME2 Marine Engine. The ME2 was made from 1958 to 1965, when it was replaced by the SEL powered ME3. 1,500 were made.", "2008-10-10 18:45:00", 0)

        IE(oC, 241, "David Auld", "Traction Engine", "1966-1980s", "Stich", "", 1, "(Photo by John Harris)", "2007-10-14 09:22:00", 0)

        IE(oC, 242, "David Auld", "Stationary", "1966-1980s", "Stich", "", 1, "Example of a verticle and horizontal engine", "2007-10-14 09:22:00", 0)

        IE(oC, 243, "Brimo", "Stationary 1", "1962-63", "Stich", "", 1, "Brimo stationary engine", "2007-10-14 09:31:00", 0)

        IE(oC, 244, "Brimo", "Stationary 2", "1962-63", "Stich", "", 1, "Brimo stationary engine", "2007-10-14 09:31:00", 0)

        IE(oC, 245, "Mamod", "MM2", "1958-1962", "Lewis", "http://www.lewismamods.piczo.com", 2, "", "2007-07-26 23:12:00", 0)

        IE(oC, 246, "Philcraft", "Lilliput Horizontal", "1990s", "Roly Williams", "http://rolywilliams.com/philcraft_lilliput.html", 2, "Kit manufactured c1990, assembled 2007.  This is a horizontal boilered variation of the Jenny Wren. Many of the same parts are used.", "2007-07-22 15:24:00", 0)

        IE(oC, 247, "MF Steam", "MF Twin", "2007", "mc_mc", "", 3, "The MF Twin is a replica of the Mamod MM1 Twin cylinder over type engine.  The replica is beatifuly engineered and is extremly high quality and runs almost silently.  Mine is number 8 of 100", "2007-10-14 09:52:00", 0)

        IE(oC, 248, "Mamod", "SE1", "1948", "Mamodman123", "http://www.mamodsteam.tk/", 2, "Strange style end caps on this one. Used around that period on some engines. A definate SE1 as shown on the box lid. Owned by mamodman123 ", "2007-10-15 20:05:00", 400)

        IE(oC, 249, "Hobbies", "SC3", "1939/1940", "Mamodman123", "http://www.mamodsteam.tk/", 2, "Produced in and around 1939/40 (Mamod and Hobbies variants) these SC engines featured lineshafts screwed on to their bases. With the deletion of the countershaft on the SC3/3/4 they are easy to identify but very very rare. No exact numbers are know to have been built. Owned by Mamodman", "2007-10-15 20:06:00", 0)

        IE(oC, 250, "Mamod", "TE1A", "1967/68", "Mamodman123", "http://www.mamodsteam.tk/", 2, "Stright levered TE1A. Produced in 1967 Mamod's reversing Traction engine. This is the very first example that reversed. The engine still has TE1 on the smokebox not to waste parts. Owned by Mamodman ", "2007-10-15 20:07:00", 0)

        IE(oC, 251, "Mamod", "TE1A", "1968-72", "Mamodman123", "http://www.mamodsteam.tk/", 2, "The very popular TE1a. With the very popular and well drawn box. Arguebly Mamod's best box art. 1968-1972. Owned by Mamodman", "2007-10-15 20:15:00", 0)

        IE(oC, 252, "Mersey Model Co Ltd", "51", "1930s", "Spokesman", "http://spokessmann.tripod.com/index.html", 2, "The Mersey 51 was the entry level engine in the fine Mersey range, which has produced so truly memorable engines and mind boggling about of variations. this little engine was repaired in 2008 and happily steams using a Luton Bowman PW201/2 burner.", "2008-10-20 18:50:00", 0)

        IE(oC, 253, "Mamod", "ME3", "1965-72", "Spokesman", "http://spokessmann.tripod.com/index.html", 1, "Mamod ME3 marine engine dating from 1965-1972. One of 2,700 produced. Utilises an SEL 1560 engine unit. Owned by Spokesmann. Boxed/complete.", "2007-10-16 18:06:00", 0)

        IE(oC, 254, "Mamod", "SR1A", "1967", "Spokesman", "http://spokessmann.tripod.com/index.html", 1, "Rare 1967 straight levered SR1a with aluminium rolls.", "2007-10-16 18:08:00", 0)

        IE(oC, 255, "Bowman", "M122", "2007", "Spokesman", "http://spokessmann.tripod.com/index.html", 1, "Bowman M122 'D' concept engine built around a standard M122. Build in progress through 2007.", "2007-10-16 18:10:00", 0)

        IE(oC, 256, "Mamod", "Meteor", "1949-1952", "Drexelius", "", 4, "This is a Mamod Meteor that I acquired several years ago. It has never been fired and is in perfect condition. Mamod only made these models for three years, from 1949-52. They, along with their electric-driven counterpart, the Conquerer, were the only commercial 'failures' that Mamod ever produced. Apparently they were too expensive for the toy market of the time and for some reason people were becoming less interested in steam launches. ", "2007-10-22 21:27:00", 0)

        IE(oC, 257, "Bowman", "E158", "mid 1920s", "Spokesman", "http://spokessmann.tripod.com/index.html", 3, "Rare Bowman E158 dating from mid 1920s. The engine has a wooden base unlike its metal based brother the M158.  The engine comes complete with burner, filler funnel and ply-wood box. The 'E' series engines are generally rarer than their 'M' series counterparts", "2007-10-29 20:53:00", 0)

        IE(oC, 258, "Scorpion", "Horizontal Scorpion", "1945 - 1956", "Tony Muir (tmuir)", "http://www.freewebs.com/ozsteam/index.htm", 4, "This was the first complete steam plant that Model Engineering produced. The boiler is a simple affair. It is made from a rolled sheet of brass with just a safety valve and a hole for the steam pipe and sometimes a filler plug. It is held into the firebox by " & "a screw soldered into one of the boiler's endcaps. You will notice it uses the same flywheel and safety valve as the vertical model. It was made between 1945 and 1956. There are a few of variations to this model. <br>  1.  The firebox opening at the funnel end could be square or round. Don't know when this change took place but do know of an engine with the square opening that was a Christmas present in 1948. The round ones also has an extra hole above it in the firebox to make it easier to tighten the nut that holds the boiler in place.<br>  2. It appears that this model came with or without a filler plug on top of the boiler. <br>  3. The firebox could come in red or black paint", "2007-11-27 15:07:00", 0)

        IE(oC, 259, "Bowman", "M180", "1936", "Spokesman", "http://spokessmann.tripod.com/index.html", 4, "Bowman M180 dating from 1936. The M180 was Bowmans smallest and last steam stationary engine, and was very much an end of production economy model which had a tinplate rolled chimney and mazak engine frame and disc crank.", "2007-12-22 20:12:00", 0)

        IE(oC, 260, "Bowmans of Luton", "PW202", "1946-1950", "Spokesman", "http://spokessmann.tripod.com/index.html", 3, "The Luton Bowmans were made by a company called Piece Parts and Assemblies from around 1946-50. The PW202 is arguably the hardest to find of their 3 stationary engines. This model was purchased at STiA 2008 and has be simpathetically refurbished to a high standard. It is shown here with its PW202 and PW203 brothers.", "2008-02-16 08:20:00", 0)

        IE(oC, 261, "Bowman", "M158", "1925 - 1930s", "Spokesman", "http://spokessmann.tripod.com/index.html", 3, "The Bowman M158 dates from mid 1920s to early 1930s. This engine has the optional chimney which was available for this engine. Basically a single cylinder M140, the M158 is a compact powerful engine unit. This engine comes complete with its box, burner, filler funnel and very rare Bowman 'Tags'.", "2008-02-19 21:27:00", 0)

        IE(oC, 262, "Karsten Gintschel", "Radial Turbine", "2007", "Duncandumpertruck", "", 2, "", "2008-02-23 10:57:00", 0)

        IE(oC, 263, "Karsten Gintschel", "P40 Turbine", "2007", "Duncandumpertruck", "", 2, "A standalone turbine with no boiler", "2008-02-23 10:58:00", 0)

        IE(oC, 264, "Karsten Gintschel", "Electro Generator Steam Turbine", "2007", "Duncandumpertruck", "", 3, "The little turbine will happily spool up and light the four leds brightly.", "2008-02-23 11:10:00", 0)

        IE(oC, 265, "Fleischmann", "125-4", "1963-65", "Duncandumpertruck", "", 3, "", "2008-02-23 11:13:00", 0)

        IE(oC, 266, "Bohm", "HB14", "2004", "Duncandumpertruck", "", 2, "Twin Cylinder Sterling Engine", "2008-02-23 11:15:00", 0)

        IE(oC, 267, "Fleischmann", "125-2", "circa 1966", "Sandy Hunter (sandman)", "http://www.freewebs.com/sandmansteamshack/index.htm", 2, "", "2008-03-12 23:11:00", 0)

        IE(oC, 268, "Mamod", "SE1", "1967", "Spokesman", "http://spokessmann.tripod.com/index.html", 3, "1967 Mamod SE1, probably one of the last to be made. Union bolt steam pipe fixing and superheated, driving a piston with oil felt pad lubricator engine block. Complete and boxed. Replaced by the SE1a in the same year.", "2008-03-15 19:14:00", 800)

        IE(oC, 269, "Bowman", "E101", "late 1920s to early 1930s", "Spokesman", "http://spokessmann.tripod.com/index.html", 3, "The Bowman E101 is a wooden based version of the M101, Bowman's biggest stationary steam engine. It can run for over an hour and a half on one filling. This engine dates from late 1920s - early 1930s. This engine is in playworn original condition.", "2008-04-05 11:08:00", 0)

        IE(oC, 270, "Plane Products", "Latimer L4", "1950s", "Spokesman", "http://spokessmann.tripod.com/index.html", 3, "The Latimer L4 made by Plane products, Teddington around 1950 was the company's smallest engine, and features a safety valve built into the chimney. The engine is boxed and complete and is in playworn original condition.", "2008-04-14 08:24:00", 0)

        IE(oC, 271, "Mamod", "MM2", "1953", "Spokesman", "http://spokessmann.tripod.com/index.html", 2, "The Mamod Minor no. 2 was introduced in about 1948. This example dates from 1953 and curiously features a mazak flywheel but in the 'hot stamped  brass' type pattern. The engine is in entirely original condition, but features a professionally reproduced period decal by the owner.", "2008-04-14 08:31:00", 0)

        IE(oC, 272, "Weeden", "123", "1913 to early 1940s", "Robert May", "", 2, "This engine was made from 1913 until the early 1940s.  The base is made from tin plate with the fire box being blued steel or Russian steel. It has a brass boiler that has a whistle and filler plug.  They didn't use a relief valves on all engines and relied on the oscillating cylinder to fulfill that operation.  It was a popular engine since it was priced lower than most steam engines.", "2008-04-26 08:32:00", 0)

        IE(oC, 273, "Weeden", "17", "1894 to early 1933", "Robert May", "", 2, " Introduced in 1894 and remained in production into 1933.  The boilers are brass with some being nickel plated or a blued finish.  The base is tin plate with four cast lead feet.  The engine tower supports the cylinder, flywheel and a valve that by shifting the lever giving forward, neutral and reverse.  The flywheel was 2 1/2"" diameter but changed size throughout it's production time as did the whistle and some painted parts.  In 1894 the cost was $2.25 and in 1933 the price had gone up to $4.50.  There is a very informative book out on Weeden Mfg. Co. by Kenneth Trobaugh which is the best source in print.", "2008-07-06 12:48:00", 0)

        IE(oC, 274, "Weeden", "49", "1898 to early 1926", "Randy Allison", "", 2, "A large toy engine with a over sized brass boiler that is nickel plated.  There were variations of the engine which included a nickel plated base but others had a painted base of various colors.  The firebox and chimney are blued steel in which they made a two door model and a single door model which had the burner attached to the door.  Earlier models had two doors on the firebox and a lead whistle and safety valve.  This engine is considered scarce in any condition.  The 49 was made from 1898 at a cost of $5.00 until 1926 costing $7.00.", "2008-07-06 12:49:00", 0)

        IE(oC, 275, "Weeden", "500", "???", "Robert May", "", 2, "Possibly a Weeden 500.  Brass vertical engine that is alcohol fired.  Is not listed in any information I have but appears to be a model 500 but with a round base rather than a footed base.  Perhaps they were using over stocked inventory as they would be interchangable.", "2008-04-26 08:46:00", 0)

        IE(oC, 276, "Weeden", "420", "1940s+", "Robert May", "", 2, "Weeden model 420 under the control of National Playthings.  Electric fired with brass boiler and steel base painted bright red.  Engine is 10 1/2"" tall and a 4 1/4"" base.  Made in the 1940s and likely made until their closing.", "2008-04-26 08:49:00", 0)

        IE(oC, 277, "Weeden", "20", "1890s-1930s", "Robert May", "", 2, "The Model 20 is 11"" tall and 4 3/8"" diameter.  Blued steel fire box, brass boiler and dark red base which is also the burner.  The engine was introduced in the 1890s and was produced up to the late 30s.  The No.20 was the only engine that could be run on a number of fuels such as kerosene, heating oils or alcohol.  The boiler has a flue running through it and the chimney is functional.  This engine was given as a premium for subscriptions of Youth's Companion  as was the Weeden No. 1 was earlier. Some engines had embossed ""WEEDEN"" on the boiler and a twin engine named ""BIG GIANT"" was produced with very little changes.", "2008-04-26 08:54:00", 0)

        IE(oC, 278, "Weeden", "14", "1900s-1940s", "Robert May", "", 2, "The No. 14 was Weeden's most popular engine through it's manufacture from prior 1900 until 1940.  The early version has the logo embossed on the boiler end cap, a lead cast whistle and cast lead fittings on the sight glass.  The early engine was a dark Burgundy color which got brighter in each variation there after.  The engine came with a simulated governor which this engine is missing.", "2008-04-26 08:59:00", 0)

        IE(oC, 279, "Weeden", "14", "1920s", "Robert May", "", 2, "The version of the 14 had changes to it that were most notable the embossing on the boiler.  Where the early model had the logo embossed on the end cap, the 1920s version had plain end caps but the name and ""Trade Mark"" were embossed on the boiler.  They went to brass sight glass fittings and whistle.  The relief valve was a spring loaded brass valve that remained the same until the end.  The color was brighter than the earlier model but was still called red.  From the early model including the 20's model had a thin rimed nickel plated flywheel.", "2008-04-26 09:02:00", 0)

        IE(oC, 280, "Weeden", "14", "1930s", "Robert May", "", 2, "The version that came about in the 1930s was the elimination of the name embossed on the boiler.  It still had four rows of embossed rivets on the boiler as it's predecessors.  In place of the name embossed on the boiler, it was replaced by a decal placed below the boiler on the sight glass end.  As all No.14s the burner is a three wick burner that awkwardly is placed under the boiler.  For some reason a majority  of the burners have been separated from their engine and are difficult to find.  The flywheels became heavier with the outer rim much more substantial.  Keeping up like the previous versions, the color got brighter with a hint of orange.", "2008-04-26 09:06:00", 0)

        IE(oC, 281, "Weeden", "647", "1927-1933", "Robert May", "", 2, "The WEEDEN 647 is a electrified No.14.  It runs on 110 volts AC or DC with 3.7 Amps.  It was made between 1927 and 1933 as to capitalize on the popularity of the No.14.  The Bing Company in Germany was envious of the success the Weeden company enjoyed with the 14 that they made their own version.  Bing modified the 14 and called it the 70/120.  Bing's engine was black with red stripping and has some improved features but still didn't take much of Weeden's business.  As with all the No.14s, the 647 is a reversible slide valve engine.", "2008-04-26 09:09:00", 0)

        IE(oC, 282, "Weeden", "702", "1935-1940s", "Robert May", "", 2, "This is a Weeden No. 702.  Production was from 1935 to into the 1940s.  It has a cast iron base with a tin plate fire box and brass boiler.  A electrical fired boiler produces too much heat and regularily pops the relief valve.  Very fast engine and the side looks like a billboard so I utilized it.  This engine is the sibling to the 802 which was the same engine but alcohol fired.", "2008-04-26 09:11:00", 0)

        IE(oC, 283, "Mamod", "MM2", "1954-1958", "Robert May", "", 2, "", "2008-05-14 15:24:00", 0)

        IE(oC, 284, "Empire", "B43", "???", "Robert May", "", 2, "The Empire B43 is somwhat difficult to find.  It is American made and fired by electricty as were all of Empire Steam engines.  The company that made the steam engines was Metal Ware Corp. in Winscosion, USA.  They also made steam engines under such names as Empco, Sunshine Brand, Quality Brand and others.  All of Empire engines are strong, steady and heavy.  Their trade mark was the chimney.  It's purpose is for filling the boiler and it is also the relief valve.", "2008-05-14 15:24:00", 0)

        IE(oC, 285, "Empire", "B31", "1920s", "Robert May", "", 2, "The Empire B31 vertical engine shares the same mechanics as the B30 horizontal engine.  The frame and piston/cylinders are interchangeable.  The boiler is chrome plated copper and the frame is cast brass.  The engine base is cast iron and all together make it quite a heavy engine.  The chimney also functions as the filling port and relief valve.  The engine has a throttle valve and a whistle which is quite loud.  The engine was patented in 1921 and had no obvious changes through the years.", "2008-05-14 15:31:00", 0)

        IE(oC, 286, "Jensen", "Jensen #35", "1946+", "Robert May", "", 1, "Early model No. 35.  Introduced in 1946 which used a piece of pine wood for the base.  Later in the 50s they changed from a pine board to plywood.  It is electric heated and runs fast all the time since it does not have a throttle.", "2008-05-14 15:39:00", 0)

        IE(oC, 287, "Bing", "70-120", "???", "Robert May", "", 2, "The Bing 70/120 was produced by Bing to take advantage of the success that Weeden was enjoying with their model 14.  Without studying the engine, it looks like Weeden's 14 only with different colors. After looking very close, I don't believe there is a part that is interchangeable.  The Bing engine will be 1/4"" longer on the boiler and 1/8"" shorter on the frame.  The Bing being metric eliminates all the small parts to interchange.  The Bing has a larger and fancier flywheel that is chrome plated on the outer face and pin stripping on the spokes.  The frame is painted black and red pin stripping. It has the typical German sight glass and a in-line oiler.  Like the Weeden 14, it has a three-wick burner but much easier to use that the Weeden engine.", "2008-05-14 15:42:00", 0)

        IE(oC, 288, "Mamod Accessories", "Lineshaft", "1953", "Spokesman", "http://spokessmann.tripod.com/index.html", 2, "1953 Mamod flatbase lineshaft. This was the last of the line for the flat base lineshafts. It features the new mazak flywheel and pedestal supports along with the (then) new red oval decal. A rare combination which lasted for approximately one year.", "2008-06-01 11:41:00", 0)

        IE(oC, 289, "Burnac", "Vulcan", "1946-69", "Spokesman", "http://spokessmann.tripod.com/index.html", 3, "Burnac Vulcan dating from 1946-69. This version has a copper boiler and brass boiler top. It is equipped with a bing type sight glass.", "2008-06-01 11:45:00", 0)

        IE(oC, 290, "Weeden", "648", "1927-1940", "Robert May", "rjbodogs@yahoo.com", 2, "This engine was introduced in 1927 and continued into production up to 1940.  Electric fired which Weeden was promoting due to the risk of accidental fires in the alcohol models.  In 1926 Weeden started a change over electrifying a good number of their production models.  This engine is a take-off of the famous model 14 which added a cast iron base which added weight to a already heavy engine.  The boilers did not have the embossed rivets as the 14 had but otherwise were mostly the same.  This particular engine has a rare option of nickel plating on the boiler and all the fittings.", "2008-07-06 12:32:00", 0)

        IE(oC, 291, "Weeden", "7", "1890-1907", "Robert May", "rjbodogs@yahoo.com", 2, "The Weeden number 7 was advertised as the engine that runs the country.  It was a miniature of what factories used in the day.  It was made from 1890 to 1907 and sold for $1.25 with a wooden box.  The boiler has seven rows of rivets on the solid brass boiler with a weight-levered safety valve.  The whistle operates from a screw valve and the engine is throttled.  The sub-base is tin with the engine base being brass.  The firebox has steel sides with brick embossing and painted red.  The ends are steel and made to resemble cast iron facade.", "2008-07-06 12:34:00", 0)

        IE(oC, 292, "Weeden", "672", "1930-1940", "Robert May", "rjbodogs@yahoo.com", 2, "Made from 1930 to 1940.  A cast iron base engine with cast lead parts makes this a heavy engine.  Fired by electricity, it's a fast and strong runner.  The boiler and firebox are nickel plated brass which has a filler/relief valve, whistle and water sight glass.  It has a reversible engine and was fitted with a throttle in 1935.  The engine cost $7.75 in 1930.", "2008-07-06 12:37:00", 0)

        IE(oC, 293, "Weeden", "155", "1918-1920s", "Robert May", "rjbodogs@yahoo.com", 2, "This is the smallest of three engines that Weeden made alike.  The 155, 156, & 157 were the same except for the size and flywheel.  The 155 had a cast lead nickel plated flywheel and the 156 & 157 had cast iron.  The engine was made from 1918 to the early 20s with low production numbers which makes this engine fairly rare.  It has a cast iron base with a nickel plated brass boiler.  It closely resembles a German made engine and appeared much different than most Weeden entries.  The 155 is 11"" tall, the 156 is 12"" and the 157 13 1/2"" tall.", "2008-07-06 12:41:00", 0)

        IE(oC, 294, "Weeden", "Mighty-Mite", "1927-1931", "Robert May", "rjbodogs@yahoo.com", 2, "The Mighty-Mite was built by Weeden from Mongomery Wards design and sold exclusively by Montgomery Ward & Co.  It is a small engine with the base being 5"" x 5"" and the engine is 6"" tall.  The base is punched out to accommodate Erector and Meccano construction sets driven from a small pulley on the flywheel.  It has a Bowman type burner and more than adequate to heat the small boiler.  The engine was made from 1927 until 1931 and sold for $1.50.", "2008-07-06 12:41:00", 0)

        IE(oC, 295, "Marklin", "#7", "1919-1920", "Vic", "http://www.freewebs.com/isettasteam/", 1, "A Marklin #7 convertible. It can be run in horizontal or vertical position. Approx date is 1919 to 1920, alcohol fired.  This is a very rare engine and very hard to find in this condition or any condition.", "2008-07-06 13:02:00", 0)

        IE(oC, 296, "Weeden", "341", "1929", "Vic", "http://www.freewebs.com/isettasteam/", 1, "", "2008-07-06 13:03:00", 0)

        IE(oC, 297, "Unknown", "Jensen #45 Modified", "???", "Vic", "http://www.freewebs.com/isettasteam/", 1, "NOW IDENTIFIED AS A MODIFIED JENSEN #45.   SEE MAIN ENTRY IN JENSEN SECTION. <br>This green engine is a mystery engine. No clue as of year, mfg, etc. Runs well", "2008-07-06 13:05:00", 0)

        IE(oC, 298, "Bowman", "M167", "1920s-1935", "Spokesman", "http://spokessmann.tripod.com/index.html", 5, "The Bowman M167 dates from around mid 1920s-35. It is basically an M158 without a countershaft. This engine has been fully cleaned and lubricated. A new decal has been added to the base plate. Apart from that the engine is entirely original. ", "2008-08-02 22:00:00", 0)

        IE(oC, 299, "Mamod", "TE1", "1963", "Kritika", "http://www.kritika.co.uk/index.html", 2, "Nut and Bolt Mamod TE1 with flat canopy, gold lettering and grooved back wheels , probably the first batch of TE1's ever from early 1963.", "2008-08-13 14:35:00", 0)

        IE(oC, 300, "David Auld", "Traction Engine", "1970", "Kritika", "http://www.kritika.co.uk/index.html", 1, "1970 Auld Traction Engine, made by David Auld in Graymouth on the west coast of New Zealand", "2008-08-13 14:37:00", 0)

        IE(oC, 301, "Wells", "Traction Engine", "1970", "Kritika", "http://www.kritika.co.uk/index.html", 1, "Wells Traction Engine, built in the New Zealand Addington (Railway) Workshops, possibly by an apprentice around the early 70s.", "2008-08-13 14:39:00", 0)

        IE(oC, 302, "Fleischmann", "155-1", "1951", "Kritika", "http://www.kritika.co.uk/index.html", 1, "Ths model was made in US Zone Germany about 1951 and exported to the US.", "2008-08-13 14:40:00", 0)

        IE(oC, 303, "Wilesco", "Tractor - TE", "1966", "Kritika", "http://www.kritika.co.uk/index.html", 1, "This is the first example of a Wilesco mobile - the famous Traction Engine first introduced into their range in 1966", "2008-08-13 14:43:00", 0)

        IE(oC, 304, "Mamod", "TE1A (Old Glory)", "2000", "Kritika", "http://www.kritika.co.uk/index.html", 1, "In 2000 Mamod made a limited number of 250 special edition TEs that were sold through the Old Glory Steam Magazine, this is the No #1.", "2008-08-13 14:47:00", 0)

        IE(oC, 305, "Mamod", "SR1", "1962", "Kritika", "http://www.kritika.co.uk/index.html", 1, "This is a 1962 Mamod SR1, the main difference between the first ever SR1's of 1961 and the 1962 and 1963’s models are two flat headed brass rivets directly under the cam rod.", "2008-08-13 14:49:00", 0)

        IE(oC, 306, "Bowman", "E101", "1925 to 1929", "Kritika", "http://www.kritika.co.uk/index.html", 1, "The Bowman E101 is a wooden based version of the Bowman M101, Bowman's biggest stationary steam engine.", "2008-08-13 14:51:00", 0)

        IE(oC, 307, "Mastrand", "Steam Roller", "1950", "Kritika", "http://www.kritika.co.uk/index.html", 1, "Mastrand Steam Roller of the 1950's was to later become the inspiration for Mamod's first  mobile - the SR1 Steam Roller.", "2008-08-13 14:52:00", 0)

        IE(oC, 308, "Bowman", "M122D", "2008", "Spokesman", "http://spokessmann.tripod.com/index.html", 3, "The engine featured here is what the owner describes as a Bowman M122D. Basically an M122 with Doll type dynamo attached. The engine has been completely refurbished to a very high standard from a wreck. The custom paint colours are the 'reverse' of the normal colour way of the M122.", "2008-10-08 21:36:00", 0)

        IE(oC, 309, "Wilesco", "Traction Engine TB300", "1986-1992", "Kritika", "http://www.kritika.co.uk/index.html", 1, "Wilesco Traction Engine, this is a special edition of the 'Esso Blue' model made by Wilesco for the German market in the 1970s.  Date revised from information given by Manuela Huvendiek.", "2014-02-04 21:23:00", 0)

        IE(oC, 310, "Mamod", "TE1A", "1972", "Kritika", "http://www.kritika.co.uk/index.html", 1, "This is the 'classic' Mamod TE from Mamod's 'Golden Era'.", "2008-10-08 21:47:00", 0)

        IE(oC, 311, "Cranko", "Steam Roller 3", "1946-1957", "Kritika", "http://www.kritika.co.uk/index.html", 1, "Donald Cranko made these steam toys in Havelock North, New Zealand and traded under the name of Movie Models 1946 - 1957.", "2008-10-08 21:49:00", 0)

        IE(oC, 312, "Bowman", "M101", "1920s-1930s", "Spokesman", "http://spokessmann.tripod.com/index.html", 2, "A Bowman M101 dating from around late 1920s/early 1930s. This engine was refurbished in Autumn 2008 and exhibits a grooved type flywheel as opposed to the plain variety. Engine was refurbished using new MFSteam parts and turned out to a very high standard.", "2008-10-10 18:39:00", 0)

        IE(oC, 313, "Mamod", "TWK1", "1982", "Spokesman", "http://spokessmann.tripod.com/index.html", 3, "The Tractor and Wagon Kit, TWK1, was Mamod's first kit steam engine introuced in 1982. This engine was purchased as a made up kit and has been steamed once. The rarer TWS was a ready to run built version with slightly modified smokebox door. Still in production (2008). The engine is fitted with an owner installed canopy.", "2008-10-10 18:47:00", 0)

        IE(oC, 314, "Mamod", "SA1", "1976", "Spokesman", "http://spokessmann.tripod.com/index.html", 4, "The Steam Roadster was introduced by Mamod in 1976. This Steve Malins design originally featured a meths burner, artillery style wheels (SE3 flywheels) and over-flow plug boiler. This early models dates from this period. Later models featured sight-glass boilers, redesigned wheels and solid fuel burners. Split rear drive was also a feature of early models.", "2008-10-11 09:48:00", 0)

        IE(oC, 315, "Meccano", "Vertical Engine", "c1914-1918", "Mike", "http://mikes-steam-engines.co.uk/", 2, "", "2008-10-11 10:09:00", 0)

        IE(oC, 316, "Meccano", "Horizontal Engine (Vertical Boiler)", "c1929", "Mike", "http://mikes-steam-engines.co.uk/", 1, "", "2008-10-11 10:09:00", 0)

        IE(oC, 317, "Meccano", "1970s Horizontal Engine", "1970s", "Mike", "http://mikes-steam-engines.co.uk/", 1, "", "2008-10-11 10:14:00", 0)

        IE(oC, 318, "Meccano", "1970s Horizontal Engine (New Box)", "1970s", "Mike", "http://mikes-steam-engines.co.uk/", 1, "", "2008-10-11 10:14:00", 0)

        IE(oC, 319, "Wilesco", "D455", "1990", "Spokesman", "http://spokessmann.tripod.com/index.html", 3, "This D455 dates from 1990 and is in original steamed condition, the engine has been in the Wilesco range for over 30 years and is their best vertical boilered engine in my view.", "2008-10-20 18:42:00", 0)

        IE(oC, 320, "Mamod", "SP3", "1979", "Spokesman", "http://spokessmann.tripod.com/index.html", 1, "The Mamod SP3 dates from 1979 and effectively was a Meccano MEC1, but with sight glass, sprung re-set whistle and solid fuel tray. It was dropped from the range in 1985.", "2008-10-20 18:45:00", 0)

        IE(oC, 321, "Mamod", "SP5", "1983", "Spokesman", "http://spokessmann.tripod.com/index.html", 1, "This Mamod SP5 twin dates from 1983. It was introduced into the updated stationary range in 1979 and featured exhaust to chimney and twin reversible cylinders. Production of this fine engine ceased in 1985, along with the SP1 and SP3.", "2008-10-20 18:48:00", 0)

        IE(oC, 322, "Mamod", "SE2A", "1972-75", "Spokesman", "http://spokessmann.tripod.com/index.html", 3, "Mamod SE2a dating from c1972-75. The SE2a replaced the venerable SE2 in 1967. It was the first small Mamod stationary engine to be reversible. The particular example has been completely restored to near showroom condition and features one of the owners own reproduction decals.", "2008-10-25 11:03:00", 0)

        IE(oC, 323, "MF Steam", "MF Twin", "2007", "Spokesman", "http://spokessmann.tripod.com/index.html", 2, "The MFtwin is a faithful copy of the mega-rare pre-ward Mamod MM2. This engine being just no. 004 in the initial production batch of 10. In all the total run will be 100 pieces. The engine is in mint, unfired condition and has the added addition of a professional reproduced decal from the owners own range.", "2008-10-25 11:32:00", 0)

        IE(oC, 324, "Burnac", "Vulcan", "1946-1949", "John Chapman", "http://www.steamtoys.co.uk", 1, "A Burnac Vulcan with a copper boiler barrel and a steel boiler cap.  This engine also has the alternate design of boiler sight glass.", "2008-10-25 11:37:00", 0)

        IE(oC, 325, "Falk", "Candle Stick", "pre-1914", "John Chapman", "http://www.steamtoys.co.uk", 1, "A 'candle stick' engine, made, in Nuremberg, by Josef Falk.  It is marked 'Made in Germany' and so is probably pre WW1 (pre 1914). Engines imported into Britain after the war were not usually branded 'Made in Germany'.", "2008-10-25 11:42:00", 0)

        IE(oC, 326, "Gem", "Horizontal Boiler", "1950", "John Chapman", "http://www.steamtoys.co.uk", 1, "An engine by Gem Products of Wiltshire, U.K.  Their logo was a red triangle, the ghost image of which is visible on each side of the brass boiler shroud.", "2008-10-25 11:46:00", 0)

        IE(oC, 327, "Cyldon", "13-1", "c1946", "John Chapman", "http://www.steamtoys.co.uk", 1, "", "2008-10-28 08:06:00", 0)

        IE(oC, 328, "Mamod", "SE2", "1954-1958", "Spokesman", "http://spokessmann.tripod.com/index.html", 3, "Here we have a early raised base SE2 displaying the classic features of the period: thick-rimmed flywheel, long handled whistle and good build quality all round. This example is in original playworn condition and comes complete with the maroon strawboard box. This engine existed in this forum until approx 1958, when a redesigned and wider firebox was introduced as well as a vapourising spirit lamp.", "2008-10-28 08:08:00", 701)

        IE(oC, 329, "Meccano", "MEC1", "1970", "Spokesman", "http://spokessmann.tripod.com/index.html", 3, "The Meccano engine or MEC1 was made by Malins Engineers to a design laid down by the Liverpool company (Meccano). The MEC1 as it was known was the first Malins made engine to feature a simple but effective reversing control, achieved by altering the position of the cylinder relative to the inlet/exhaust ports. It was made from 1965 until 1976, about 83,000 were made. This version dates from 1970 as it has a 'Powerdrive' blue window box. Engine is is playworn condition.", "2008-11-01 09:23:00", 0)

        IE(oC, 330, "Fleischmann", "105-1", "c1964", "Les", "http://www.freewebs.com/lesmarsh/", 1, "", "2008-11-01 09:31:00", 0)

        IE(oC, 331, "Fleischmann", "120-1", "c1962", "Les", "http://www.freewebs.com/lesmarsh/", 1, "", "2008-11-01 09:33:00", 0)

        IE(oC, 332, "Fleischmann", "120-1", "c1968", "Les", "http://www.freewebs.com/lesmarsh/", 1, "", "2008-11-01 09:34:00", 0)

        IE(oC, 333, "Fleischmann", "121-3", "c1953", "Les", "http://www.freewebs.com/lesmarsh/", 1, "", "2008-11-01 09:35:00", 0)

        IE(oC, 334, "Fleischmann", "122-3", "c1956-60", "Les", "http://www.freewebs.com/lesmarsh/", 1, "", "2008-11-01 09:36:00", 0)

        IE(oC, 335, "Fleischmann", "122-4", "c1956", "Les", "http://www.freewebs.com/lesmarsh/", 1, "", "2008-11-01 09:37:00", 0)

        IE(oC, 336, "Fleischmann", "125-2", "c1966", "Les", "http://www.freewebs.com/lesmarsh/", 1, "", "2008-11-01 09:38:00", 0)

        IE(oC, 337, "Fleischmann", "125-4", "c1959", "Les", "http://www.freewebs.com/lesmarsh/", 1, "", "2008-11-01 09:39:00", 0)

        IE(oC, 338, "Fleischmann", "130-2", "c1960", "Les", "http://www.freewebs.com/lesmarsh/", 1, "", "2008-11-01 09:40:00", 0)

        IE(oC, 339, "Major Toy", "Red Injun", "1940s to ???", "Mos6502", "", 2, "These were available as a sterno heated version (shown) and as an electrically heated version.  Despite looks, the cylinder is only single acting, not double. ", "2008-11-01 09:51:00", 0)

        IE(oC, 340, "Robert Fulton", "Vertical", "1940s to 1950s", "Mos6502", "", 1, "These came in many variations, including a sterno fired version, a slide valve version, and a variant with a water sight glass.  The boiler is made of steel and is welded together instead of soldered, so even if run dry the boiler cannot be ruined (according to the instructions anyway).  The flywheel and cylinder are pot metal, and the cylinder is double acting. ", "2008-11-01 09:57:00", 0)

        IE(oC, 341, "Weeden", "400", "1937 to 1940", "Mos6502", "", 1, "Electrically heated Weeden vertical with water sight-glass and thick rimmed nickel plated flywheel.", "2008-11-01 09:58:00", 0, "http://www.youtube.com/watch?feature=player_embedded&v=vWI2ooawazg")

        IE(oC, 342, "Philcraft", "Marine Engine", "2008", "Roly Williams", "http://rolywilliams.com/philcraft_marine.html", 5, "To quote the maker (Phil Gravett) ""this engine unit was originally designed to go in a 15"" open launch designed by Richard White of ship and boat international, but be able to slip into any suitable hull  instantly. ... it is just a v twin variation on the Jenny Wren but with a stainless superheater. It needs this as the ceramic burner glows red hot. the boiler is Simpson Strickland Kingdom type in look although no tubes.""", "2008-11-09 08:21:00", 0)

        IE(oC, 343, "Mamod", "SE1", "1946", "Spokesman", "http://spokessmann.tripod.com/index.html", 3, "This version of the ubiquitous SE1 appeared in 1946 and was basically the same as the pre-war SE1, but for a locomotive style chimney. This engine has been completely refurbished to a high degree with replacement engine frame/cylinder and decal.", "2008-11-09 08:28:00", 300)

        IE(oC, 344, "Mamod", "MM1", "1940s", "Atticman", "", 2, "The MM1 had a raised base a couple of years earlier than the rest of mamod range.", "2008-11-10 08:02:00", 0)

        IE(oC, 345, "Mamod", "MM1", "c1949", "Spokesman", "http://spokessmann.tripod.com/index.html", 1, "A rare post-war Minor with the 'new' raised base, probably done when the Camden Street move was made in 1949. Red disc crank with period barrel cylinder/piston. In totally original condition. Show with a mid 1950s Mazak-wheeled version.A rare post-war Minor with the 'new' raised base, probably done when the Camden Street move was made in 1949. Red disc crank with period barrel cylinder/piston. In totally original condition. Pictured with a mid 1950s Mazak-wheeled version.", "2008-11-12 20:19:00", 0)

        IE(oC, 346, "Wilesco", "D20", "c1980s", "John Reid", "http://www.freewebs.com/johnreid", 2, "", "2008-11-20 17:49:00", 0)

        IE(oC, 347, "Wilesco", "D8", "2008", "John Reid", "http://www.freewebs.com/johnreid", 2, "", "2008-11-21 07:59:00", 0)

        IE(oC, 348, "Fleischmann", "135-2", "1959", "John Reid", "http://www.freewebs.com/johnreid", 2, "", "2008-11-21 08:03:00", 0)

        IE(oC, 349, "Mamod", "SE3", "1967-71", "Spokesman", "http://spokessmann.tripod.com/index.html", 3, "This rare variation of the SE3 features screw-on cranks and push button whistle. It has been cleaned as is presented in playworn condition.", "2008-12-08 21:45:00", 0)

        IE(oC, 350, "DEO", "Stationary", "???", "Les", "http://www.freewebs.com/lesmarsh/", 3, "", "2008-12-11 07:45:00", 0)

        IE(oC, 351, "Line Mar", "Stationary", "???", "Mos6502", "", 2, "The boiler is made of two tin plate stampings, and it is fueled by a tiny can of sterno - later models are fueled with solid tablets - and the very last models have a brass boiler.", "2008-12-11 18:25:00", 0)

        IE(oC, 352, "Bowman", "M101", "late 1920s", "James Chantry", "www.mamodforums.co.uk ", 1, "This engine was bought from good friend and fellow collector James Kite. It's an early model with no groove in the flywheel and a strange endcap on the boiler (long thought to be a later addition, though now proved not to be!).", "2008-12-14 10:25:00", 0)

        IE(oC, 353, "Bowman", "M122", "1920-1930s", "James Chantry", "www.mamodforums.co.uk ", 1, " Bought from Mooseman, this very fine M122 must be one of the best surviving of its type still in it's original clothes!", "2008-12-14 10:28:00", 0)

        IE(oC, 354, "Bowman", "M158", "1920-1930s", "James Chantry", "www.mamodforums.co.uk ", 1, "Bought from the 2008 STIA for around £25. She's in rough, unrestored condition, but she still runs sweet as a nut!", "2008-12-14 10:29:00", 0)

        IE(oC, 355, "Bowmans of Luton", "PW201", "1946-1950", "James Chantry", "www.mamodforums.co.uk ", 1, "This engine came from the Netherlands, via a member of the Unofficial Mamod and Other Steam Forum. It was just a box of parts, and has been restored and has had a new chimney made. ", "2008-12-14 10:30:00", 0)

        IE(oC, 356, "Fleischmann", "135-2", "1958", "James Chantry", "www.mamodforums.co.uk ", 1, "Bought off German ebay via Mooseman, whom I bought it from at the 2008 STIA. The 135/2 is a massive engine, and dwarfs any Mamod!!", "2008-12-14 10:32:00", 0)

        IE(oC, 357, "Hobbies", "SE1", "1936", "James Chantry", "www.mamodforums.co.uk ", 1, "This little beauty was bought from James Kite, at STIA 2008. She's in wonderful condition, and still has her original box. One of only 3 I know of (all of which belonged to James Kite at the same time!!)", "2008-12-14 10:34:00", 0)

        IE(oC, 358, "Hobbies", "SE2", "1936", "James Chantry", "www.mamodforums.co.uk ", 1, "Marvellous little engine here, bought from Sandra. Still has the box, and the decal is in near mint condition!", "2008-12-14 10:35:00", 0)

        IE(oC, 359, "Jensen", "Jensen #75", "1960s", "James Chantry", "www.mamodforums.co.uk ", 1, "This engine is great! One of the earlier ones with 'copper clad' firebox instead of the more modern 'pink' painted firebox.", "2008-12-14 10:36:00", 0)

        IE(oC, 360, "Jensen", "Jensen #76", "???", "James Chantry", "www.mamodforums.co.uk ", 1, "My first Jensen, about the same size as a Mamod SE1/2. Well built, this engine once graced the shelves of the Temple of Steam.", "2008-12-14 10:37:00", 0)

        IE(oC, 361, "Jensen", "Jensen #65", "???", "James Chantry", "www.mamodforums.co.uk ", 1, "In unfired condition.", "2008-12-14 10:38:00", 0)

        IE(oC, 362, "Jensen", "Jensen #35", "???", "James Chantry", "www.mamodforums.co.uk ", 1, "", "2008-12-14 10:39:00", 0)

        IE(oC, 363, "Jensen", "Jensen #70", "???", "James Chantry", "www.mamodforums.co.uk ", 1, "In rough condition, but cost all of £9 from American eBay!", "2008-12-14 10:40:00", 0)

        IE(oC, 364, "Jensen", "Jensen #5", "???", "James Chantry", "www.mamodforums.co.uk ", 1, "Bought from well respected Jensen collector, Gil. This engine oozes quality! ", "2008-12-14 10:41:00", 0)

        IE(oC, 365, "Wilesco", "D365", "???", "James Chantry", "www.mamodforums.co.uk ", 1, "With added canopy by Steam4Fun", "2008-12-14 10:43:00", 0)

        IE(oC, 366, "Wilesco", "D22", "1970s", "James Chantry", "www.mamodforums.co.uk ", 1, "Early model, Esbit fired.", "2008-12-14 10:44:00", 0)

        IE(oC, 367, "Wilesco", "D5", "1960s", "James Chantry", "www.mamodforums.co.uk ", 1, "Early engine with no sightglass. Kit version of D6. Belonged to Roger Goodnow and then John Reid.", "2008-12-14 10:45:00", 0)

        IE(oC, 368, "Steamco", "STC-01", "2000", "James Chantry", "www.mamodforums.co.uk ", 1, "Unfired and boxed, still in production. Wonderful engines worth every penny!", "2008-12-14 10:46:00", 0)

        IE(oC, 369, "Mamod", "SE4", "1937", "James Chantry", "www.mamodforums.co.uk ", 1, "Nicely restored little SE4, the crown jewels of my collection! ", "2008-12-14 10:48:00", 0)

        IE(oC, 370, "Mamod Accessories", "Lineshaft", "1953", "James Chantry", "www.mamodforums.co.uk ", 1, "Boxed, only made for one year. Rare little flatbase lineshaft.", "2008-12-14 10:50:00", 0)

        IE(oC, 371, "Mamod Accessories", "Lineshaft", "1948-53", "James Chantry", "www.mamodforums.co.uk ", 1, "Brass flywheel lineshaft, rare and very desirable among collectors.", "2008-12-14 10:51:00", 0)

        IE(oC, 372, "Latimer Productions", "Plane L5", "late 1940s early 50s", "Spokesman", "http://spokessmann.tripod.com/index.html", 4, "The Plane products L5 (sometimes know as a Latimer L5) dates from the late 1940s - early 1950s and was made near London in Latimer Road, Teddington Middlesex. The engine shares some similarities with the Luton Bowman PW203 of the same period. This engine was the biggest in the Plane range and shares very little in the way of common parts with its smaller brother the Plane L4. This example has been refurbished to a high standard and comes complete with burner.", "2008-12-24 18:25:00", 0)

        IE(oC, 373, "Wilesco", "D14", "2008", "Spokesman", "http://spokessmann.tripod.com/index.html", 4, "The D14 is an overtype steam model, in a similar vein to the SP2 or MM2. It has been in the range for a number of years and features double acting cylinder and whistle. Earlier versions had a blue base. This one dates from 2008 and was purchased by the owner brand new.", "2009-01-01 14:09:00", 0)

        IE(oC, 374, "Crescent Toys", "Horizontal", "1947-48", "Jay Minor", "http://www.freewebs.com/mamod/", 2, "", "2009-01-01 14:12:00", 0)

        IE(oC, 375, "Bowman", "M122", "1930s", "Jay Minor", "http://www.freewebs.com/mamod/", 1, "This is a 1930s Bowman M122 in totally original condition with box.", "2009-01-02 22:04:00", 0)

        IE(oC, 376, "Line Mar", "Atomic Reactor", "1960s", "Ozsteamdemon", "", 2, "", "2009-01-22 08:25:00", 0)

        IE(oC, 377, "SEL", "Merit 1540", "late 1940s - early 50s", "Spokesman", "http://spokessmann.tripod.com/index.html", 5, "The Merit brand was another identity which belonged to J & L Randall who also owned and sold under the SEL brand. This 1540 dates from around the late 1940s, early 1950s. It is essentially a single cylinder version of the 1550 Major, and features displacement lubricator and twin wick burner. The engine is complete with box and funnel. It is shown with a Multum power saw dating from 1950s/60s - which were similar to SELs own tools", "2009-03-01 18:32:00", 0)

        IE(oC, 378, "Wilesco", "D430 (Locomobile)", "", "Jay_Minor", "http://www.freewebs.com/mamod/", 1, "", "2009-03-01 21:13:00", 0)

        IE(oC, 379, "Mamod", "TE1A", "", "Jay_Minor", "http://www.freewebs.com/mamod/", 1, "This is the short wheelbase version (with some customisations).", "2009-03-01 21:15:00", 0)

        IE(oC, 380, "Bowman", "M130", "1930s", "Unknown", "", 2, "These photos are of a Bowman M130 taken by Atticman at STIA 2009.  Dates from 1930s, and is pretty much an M135 with no countershaft and the added dynamo. Base paint is also green as opposed to the red based M135 and is quite rare.", "2009-03-02 16:40:00", 0)

        IE(oC, 381, "Mamod", "MM1", "1975-77", "Spokesman", "http://spokessmann.tripod.com/index.html", 4, "This Minor dates from c1975-77 as demonstrated by the overflow plug (introduced in the MM1 in 1975) and the fact that it has a very narrow vapourising type spirit lamp (c1970-77). After 1977 the MM1 had a solid fuel burner for a year or two before being dropped and re-introduced as the SP1. This example is in excellent playworn condition and clearly shows the labels applied to all meths engines after the 'fuel incident' of 1975 in the US.", "2009-03-13 18:07:00", 0)

        IE(oC, 382, "Wells", "Stationary", "1970s", "Alkenco", "", 4, "Based on plans from Kenneth Wells' book. Deviations include firebox made from aluminium (as apposed to steel) and differing boiler end cap construction.", "2009-04-04 08:47:00", 0)

        IE(oC, 383, "Wells", "Traction Engine", "1970s", "Alkenco", "", 4, "Based on plans from Kenneth Wells' book. Possible school project made by one D Sutton. Acquired from the Great Dorset Steam Fair in 2008, required the steam pipes soldering in place to get it running.", "2009-04-04 08:48:00", 0)

        IE(oC, 384, "PM Research", "Horizontal Boiler", "2000s", "Metalhead", "", 1, "Horizontal boiler, built from a kit by the owner.", "2009-04-07 21:54:00", 0)

        IE(oC, 385, "PM Research", "Model 2 Vertical", "???", "Metalhead", "", 1, "", "2009-04-07 21:55:00", 0)

        IE(oC, 386, "Wilesco", "D9", "2008", "Kaleb Cosier", "", 1, "The D9 is the same as the D10, but it comes as a kit. Note the peanut type steam whistle that reminds one of the old weighted lever whistles. This is also present on the D5, D6, D8, D10, D106, D455 and Spreewald loco kit, also known as Lucas or the D001. I have owned this engine from new, and it runs silky smooth, though it isn't as powerful as I first thought it should be.", "2009-04-07 21:59:00", 0)

        IE(oC, 387, "Wilesco", "D415", "2008", "Kaleb Cosier", "", 1, "The D415 is the kit version of the D405. This model is often called the 'Wilesco Tracktor' from the name embossed on the smokebox. This is my most costly engine to date, costing AU$455, and my firm favorite, too. The whistle on this model is found on all Wilesco traction engines and steam rollers, as well as the D456 vertical.", "2009-04-07 22:01:00", 0)

        IE(oC, 388, "Mamod", "MEC1", "c. 1960s", "Kaleb Cosier", "", 1, "This was my first steam engine, obtained as a wreck at a swap meet for AU$30, with no crankshaft, flywheel or level plug, but the boiler and cylinder" & "were basically intact, but the cylinder was siezed and part of the con-rod was missing. A couple of days later, it was up and running, but with no burner, we used a gas torch for heat, so we tried candles as a fuel to keep the boiler hot, with the gas torch used to raise steam. We then used metho, but the burner we made was poorly designed and often spilt burning metho on the ground. The burner was then converted to use Hexi tablets (Esbit), which has been quite a sucess. I now have a proper Mamod vap burner which I will use in it.", "2009-04-07 22:04:00", 0)

        IE(oC, 389, "Mamod", "MM2", "1958-1975", "Kaleb Cosier", "", 2, "The Mamod Minor 2 was the second smallest stationary engine made by Mamod. This one had a vap burner, indicated by the cut-outs in the base, since this engine didn't come with a burner when I got it. Like the MEC1, it is a very versatile engine, seen here as a traction engine, and a paddlesteamer.", "2009-04-07 22:07:00", 0)

        IE(oC, 390, "Mamod", "SR1A", "1967-1976", "Kaleb Cosier", "", 1, "This engine is a later SR1A, indicated by the spring-loaded whistle, and the presence of a metho burner. The burner is shared with my MEC1 and Minor 2. This steam roller is in very good condition. Just a bit of oxide on the firebox, otherwise perfect, but a bit of a sluggish runner.", "2009-04-07 22:10:00", 0)

        IE(oC, 391, "Welby", "Pop-Pop Boat", "2008", "Kaleb Cosier", "", 1, "Welby is an Indian company that makes tin toys as part of it's range. My cheapest steam-related item, it cost just under AU$10 from Hobbyco in Sydney, who also stock Wilesco steam engines. This boat just oozes that tin toy charm, and works beautifuly.", "2009-04-07 22:11:00", 0)

        IE(oC, 392, "Astromedia", "Stirling Engine", "2008/9", "Kaleb Cosier", "", 1, "Astromedia is a German company that makes cardboard kits of scientific instruments, and this LTD(Low Temperature Differential) Stirling engine. It will get up to 228 rpm on boiling water, and will also run on ice, or vegetables cooked in boiling water. This is one of the cheapest Stirling engines I can find on the market, costing 21.90 Euros, around AU$44. Keep in mind if you get one that the instructions are in German only! Luckily, my sister knows German very well, and I could supply English copies of the instructions, since she translated the instructions for my engine.", "2009-04-07 22:16:00", 0)

        IE(oC, 393, "Mamod", "SE2A", "1970-72", "Atticman", "", 3, "This example of a SE2A has the rare push button whistle.", "2009-05-02 10:42:00", 0)

        IE(oC, 394, "Mercer", "Type 2", "2009", "Kevin Roberts", "", 3, "A lovely example of the D.R.Mercer Type 2 model traction engine", "2009-05-02 10:49:00", 0)

        IE(oC, 395, "Wilesco", "D409 Showmans", "Early 90s", "Ozsteamdemon", "", 1, "", "2009-05-05 22:05:00", 0)

        IE(oC, 396, "Mamod", "SE1A", "1960s-1970s", "John Reid", "http://www.freewebs.com/johnreid", 3, "", "2009-05-06 16:56:00", 0)

        IE(oC, 397, "Wilesco", "D24", "1992", "Ozsteamdemon", "", 1, "", "2009-05-06 17:00:00", 0)

        IE(oC, 398, "Cyldon", "13-2", "c1947-511", "Spokesman", "http://spokessmann.tripod.com/index.html", 3, "An unusual engine made c1947-51 by Sydney S Bird of Enfield, Essex, under the 'Cyldon' brand name. The 13/2 features a very unusual semi-rotative valve mechanism on the single acting cylinder. The Cyldon range featured 5 engines in total. This example is in original playworn condition and features also the attractive all-brass tubular 3-wick lamp.", "2009-05-10 11:16:00", 0)

        IE(oC, 399, "David Auld", "Stationary", "c1966 - 1989", "Scorpion2nz", "http://www.freewebs.com/scorpion2nz/", 1, "This engine is unfired.", "2009-06-01 14:16:00", 0)

        IE(oC, 400, "David Auld", "Steam Crane", "c1966 - 1989", "Scorpion2nz", "http://www.freewebs.com/scorpion2nz/", 1, "In regular use and surprising in it's power", "2009-06-01 14:17:00", 0)

        IE(oC, 401, "David Auld", "Traction Engine", "c1966 - 1989", "Scorpion2nz", "http://www.freewebs.com/scorpion2nz/", 1, "Shown with canopy, a very reliable runner and in regular use.", "2009-06-01 14:18:00", 0)

        IE(oC, 402, "Cranko", "Vertical Engine", "1945-56", "Scorpion2nz", "http://www.freewebs.com/scorpion2nz/", 1, "", "2009-06-01 14:19:00", 0)

        IE(oC, 403, "Cranko", "040 O-Gauge Steam Train", "1947-52", "Scorpion2nz", "http://www.freewebs.com/scorpion2nz/", 2, "With tender and wagon", "2009-06-01 14:20:00", 0)

        IE(oC, 404, "Mamod", "1351 New Mamod Train", "2009", "John Reid", "http://www.freewebs.com/johnreid", 1, "", "2009-6-21 09:26:00", 0)

        IE(oC, 405, "Kleinemeier", "Steam Engine House", "2009", "Roly Williams", "http://rolywilliams.com/km_engine_house.html", 3, "This is an unusual compact style of stationary engine. It has a simple single oscillating cylinder engine.", "2009-07-15 22:01:00", 0)

        IE(oC, 406, "Cyldon", "13-5", "1940s", "Roly Williams", "http://rolywilliams.com/cyldon_13-5.html", 1, "A fairly conventional single cylinder double acting slide valve stationary engine. This example has been restored and repainted in a rough approximation of the original colours.", "2009-07-15 22:07:00", 0)

        IE(oC, 407, "Opitec", "420", "2007", "Roly Williams", "http://rolywilliams.com/opitec_420.html", 1, "A kit built engine.", "2009-07-15 22:09:00", 0)

        IE(oC, 408, "AB Alga", "John Ericsson", "c1970s", "Roly Williams", "http://rolywilliams.com/john_ericsson.html", 1, "A well built stationary with several unusual design features.", "2009-07-15 22:18:00", 0)

        IE(oC, 409, "Falk", "440-3", "pre 1914", "Sandy Hunter (sandman)", "http://www.freewebs.com/sandmansteamshack/index.htm", 1, "Made in prewar Germany by Joseph Falk, this little engine is in amazingly good condition and runs a treat.", "2009-07-17 08:15:00", 0)

        IE(oC, 410, "Fleischmann", "130-2", "1951-69", "Fred", "", 2, "", "2009-07-17 08:20:00", 0)

        IE(oC, 411, "Stuart Turner", "S-50 Mill Engine", "Unknown", "Ozsteamdemon", "", 2, "", "2009-08-09 20:42:00", 0)

        IE(oC, 412, "Stuart Turner", "Double 10", "1980s", "Ozsteamdemon", "", 2, "", "2009-08-09 20:46:00", 0)

        IE(oC, 413, "Multum", "Workshop", "???", "Mike", "http://mikes-steam-engines.co.uk/", 1, "Multum(Workshop) Made by  Ward & Goldstone Plastics Ltd, Tottenham Court Road, London. (Note Multum never made a steam engine to drive its workshops)", "2009-08-09 20:56:00", 0)

        IE(oC, 414, "Hobbies", "SE3", "c1937", "Mike", "http://mikes-steam-engines.co.uk/", 1, "Malins engineers (Mamod) for Hobbies Limited of Dereham(Norfolk) and sold under the Hobbies brand name. (Note Only made for Three years Total production 1000)", "2009-08-09 21:01:00", 0)

        IE(oC, 415, "Hobbies", "SE4", "c1937", "Mike", "http://mikes-steam-engines.co.uk/", 1, "Twin cylinder Steam engine. This is a very powerful engine Which runs at 2000 revelations per minute. (Note Only made for Three years Total production 1500)", "2009-08-09 21:04:00", 0)

        IE(oC, 416, "Mamod", "TWK1", "1982", "Mike", "http://mikes-steam-engines.co.uk/", 1, "The first ever Mamod offered in kit form. (Note Introduced in 1982 Total sales 9,989)", "2009-08-09 21:07:00", 0)

        IE(oC, 417, "Burnac", "Vulcan", "1946-1949", "Mike", "http://mikes-steam-engines.co.uk/", 1, "Made by Burnac Ltd. Burslem Stoken-on-Trent", "2009-08-09 21:16:00", 0)

        IE(oC, 418, "Stuart Turner", "10V", "2006", "SteamCollector", "http://www.mamodparts.com/", 2, "This was built in 2006 from a set of castings purchased from Stuart Models. The plethora of information and high quality of castings make this the perfect machining project for the junior model engineer, producing a very robust and powerful model engine. Overall height: 6 inches. Flywheel: 3 inch. Bore: 3/4 inch. Stroke:3/4 inch.", "2009-09-01 08:16:00", 0)

        IE(oC, 419, "Gaselan", "Stationary Engine", "1987", "Bernie", "", 1, "Made in East Germany, they have a dry heating element 300watt 220volts. Very heavy engine, cast boiler and base. They need a bigger element, or the boiler lagging, or both. Sweet runner with steam, will run real slow.", "2009-09-14 08:26:00", 0)

        IE(oC, 420, "Mamod", "SE2", "1957", "Spokesman", "http://spokessmann.tripod.com/index.html", 2, "This is an engine which can be termed as transitional, in as much as it has the new 1957 firebox and boiler band but continues to use the 3-wick burner and baseplate with retaining ears. This was to be the last incarnation of the engine with a wick burner. Engine has screw construction throughout and features a characteristic thick rimmed flywheel.", "2009-09-28 19:19:00", 700)

        IE(oC, 421, "Wilesco", "D305", "???", "Jacques", "", 1, "", "2009-10-07 08:25:00", 0)

        IE(oC, 422, "SEL", "1550 Major", "???", "Jacques", "", 2, "With red base.", "2009-10-21 19:21:00", 0)

        IE(oC, 423, "LS LOC", "Horizontal Engine", "Mid 80s", "DucanDumperTruck", "", 4, "Produced by LS LOC Basel, Switzerland sometime in the mid 80's (as far as i'm aware, there's very little information on these.) This model is the non gold plated type, actually the only one i've seen that isn't gold plated. Scale can be seen with the 50 pence piece and the 2 euro.", "2009-10-18 10:09:00", 0)

        IE(oC, 424, "LS LOC", "Traction Engine", "Mid 80s", "DucanDumperTruck", "", 2, "LS LOC Miniature Traction engine made mid 80's. Made by LS LOC Basel, Switzerland. This is fully gold plated. With the 50 pence piece and the 2 euro for scale. ", "2009-10-18 10:11:00", 0)

        IE(oC, 425, "Wilesco", "D405", "Late 80s", "DucanDumperTruck", "", 2, "Wilesco D405 Limited edition 'Great Oregon Steamup' One of 600. Produced late 80's.", "2009-10-18 10:16:00", 0)

        IE(oC, 426, "HAMPO", "Twin Cylinder", "1950s", "DucanDumperTruck", "", 4, "A HAMPO engine, made in Germany in the 50's. Electrically heated boiler with a twin cylinder horizontally opposed engine. The inlet porting is machined into the crankshaft. ", "2009-10-18 10:18:00", 0)

        IE(oC, 427, "Jean Comby", "Unis Horizontal Twin", "1950s", "DucanDumperTruck", "", 3, "A Jean Comby Unis Horizontally opposed oscillating twin engine. Made in France in the 50's. This is the largest engine of the Jean Comby range. ", "2009-10-18 10:22:00", 0)

        IE(oC, 428, "Mamod", "SE2", "1967", "Spokesman", "http://spokessmann.tripod.com/index.html", 3, "SE2 had been in the Mamod range since 1937, 30 years later this was the last. The final SE2 featured wider firebox, vapourising spirit lamp, SE3 crank and turned brass whistle. This example is in original playworn condition. Note the hammered green paint on the engine frame, typical of this period in Mamod's history.", "2009-10-21 19:23:00", 1100)

        IE(oC, 429, "Mamod", "SE1", "1937-1939", "Nick", "http://nicksteam.webs.com/", 5, "Early, pre-war Mamod SE1. Painted steam line (soldered to engine frame instead of union nut), brass disc crank, no exhaust to chimney, and dark 'Hobbies red' paint on underside.", "2009-10-21 19:36:00", 100)

        IE(oC, 430, "Bowman", "410", "circa 1930", "Nick", "http://nicksteam.webs.com/", 5, "Smallest of the Bowman locos. Single, cab-mounted cylinder (gear-driven to rear wheels, see pics). Also included is the original wooden box.", "2009-10-21 19:41:00", 0)

        IE(oC, 431, "Bowman", "265", "circa 1930", "Nick", "http://nicksteam.webs.com/", 3, "Second largest Bowman loco. 2 cylinder, with fluted connecting rods.", "2009-10-21 19:43:00", 0)

        IE(oC, 432, "Mamod", "SE2", "1961-63", "Spokesman", "http://spokessmann.tripod.com/index.html", 1, "This engine exhitibs classic detailing from early 1960s Malins - 'SR1' type early brass lamp, screw construction and 'SE3' type crank. The engine is in playworn condition and has been lightly refurbished.", "2009-11-28 14:32:00", 902)

        IE(oC, 433, "Mamod", "SE1", "c1965", "Spokesman", "http://spokessmann.tripod.com/index.html", 3, "This SE1 dates from c1965 and exhibits the classic period details, such as brass eyelet type engine frame rivets and 'SE3' type crank. The engine has been steamed a few times and is presented in near mint condition. It comes complete with box and inner packaging.", "2009-11-28 14:33:00", 710)

        IE(oC, 434, "Jensen", "Jensen #45", "1952", "Robertosala", "", 3, "This is an example of a brass boiler Jensen Style 45. Due to the lack of brass and other metals during the Korean War, as it was used on the war effort, the majority of Style 45s were made with steel boilers from 1953 up to 1955. Steel, water and heat is not a good combination so they rusted fast and developed pinholes that badly leaked on the heater rendering this engines unusable. You can test yours with a simple magnet. If the magnet sticks to the boiler then it is made of steel, if not then it is brass. This was the cheapest engine ever made by Jensen, but because it was difficult to build, its production was abandoned quickly by Mr. Jensen Sr. on 1955. If you happen to have a Jensen Style 45 with a brass boiler, you can be sure you have got a rare piece.", "2009-12-19 10:39:00", 100)

        IE(oC, 435, "Mamod", "SE1", "1958", "Spokesman", "http://spokessmann.tripod.com/index.html", 4, "This SE1 dates from c1958 and exhibits a lot of the new features that Malins were including in their engines of this period; such as the wider firebox and the wooden handled brass soldered vapourising spirit lamp. It also has the wire type boiler securing band and SE3 type crank. The engine is presented in original, playworn condition throughout.", "2010-1-4 17:20:00", 705)

        IE(oC, 436, "Mamod", "SE1", "1946", "Stewart Hawkins", "", 1, "", "2010-1-7 13:00:00", 205)

        IE(oC, 437, "Mamod", "MM1", "1939", "Stewart Hawkins", "", 2, "", "2010-1-7 13:00:03", 0)

        IE(oC, 438, "Jensen", "Jensen #25", "1953", "Robertosala", "", 2, "This is an example of a Jensen Style 25 cast model.   This Jensen engine was very popular among collectors and hobbyist and was kept in production longer than any other Jensen model.  This particular Jensen, shown here, has been in exhibition for many many years, behind glass in a museum. The museum retired this exhibit and I was fortunate to buy it. It was believed to be unfired.", "2010-01-22 07:58:00", 100)

        IE(oC, 439, "Wilesco", "T90 Turbine", "2009", "Ross Martin", "http://www.rosssteamstuff.webs.com/", 2, "Notes: Brought new in 2009", "2010-02-28 9:22:00", 100)

        IE(oC, 440, "Mamod", "SE1", "1958", "Spokesman", "http://spokessmann.tripod.com/index.html", 3, "This engine was completely refurbished in March 2010 and is an example of a 'transitional stationary', because it sports both the old wick type lamp and base but coupled with a new 1958 firebox and boiler band. The SE1 was made in this style for probably no more than 6 months or so.", "2010-3-29 15:21:00", 706)

        IE(oC, 441, "Mamod", "SP1", "c1979", "Swift Fox", "http://swiftfoxsteamco.webs.com/", 3, "A mint in box unfired example of a Mamod SP1 which replaced the Minor 1 in 1979 and was in production for only five years before being dropped from the range in 1984.", "2010-04-14 22:32:00", 0)

        IE(oC, 442, "Mamod", "Challenger", "March 2009", "Swift Fox", "http://swiftfoxsteamco.webs.com/", 3, "This is the slide valve variation of the Mamod SR1a which uses the same engine that features on the ‘William’ locomotive and the SP6/SP7. It also features silver soldered boiler construction and reheat tubes as well as a full length canopy, unlike the SR1a the exhaust does not go up the chimney and is a straight out in the air type. ", "2010-04-17 09:29:00", 0)

        IE(oC, 443, "Mamod", "MM2", "1968", "Robertosala", "", 5, "This is an example of an early Mamod Minor 2 with raised base. Note that this does not have an overfill plug, does not have red paint inside the chimney and the greenish color on top the boiler is kind of darker than the later Minor 2s. The burner in this sample is a reproduction.", "2010-05-12 18:19:00", 0)

        IE(oC, 444, "Philcraft", "Beam Engine", "approx 1995", "Ralph", "", 2, "An lovely example of the Philcraft Beam Engine", "2010-05-17 21:44:00", 100)

        IE(oC, 445, "Philcraft", "Steam Launch", "approx 1995", "Ralph", "", 2, "Philcraft Marine Engine mounted in a launch.  This has had radio control added as it's too precious to risk losing it on my local lake.", "2010-05-17 21:48:00", 100)

        IE(oC, 446, "Mamod", "MM2", "1978-79", "Swift Fox", "http://swiftfoxsteamco.webs.com/", 4, "This is the last iteration of the Mamod Minor 2 before it was replaced by the SP2, it features a sightglass and solid fuel burner tray and was only produced for about a year.", "2010-05-27 07:32:00", 0)

        IE(oC, 447, "Mamod", "SE1A", "1978-79", "Swift Fox", "http://swiftfoxsteamco.webs.com/", 4, "A rare example of an SE1a, this was probably manufactured in 1978/79 and was the last variant of the SE1a before being phased out in favour of the new SP range of engines. It featured a sightglass and solid fuel burner. ", "2010-05-31 13:54:00", 0)

        IE(oC, 448, "Wilesco", "D10", "1960", "Bob Colliflower", "http://www.misterbobsmodelworksemporium.blogspot.com/", 2, "This is a gray base Wlesco D10 from around 1960, purchased on Ebay in very dusty condition. ", "2010-05-31 13:59:00", 0)

        IE(oC, 449, "Jensen", "Jensen #20G", "14-Sep-2009", "Dauntless", "http://dauntless-steam-engines.webs.com/ ", 2, "I had this engine made to order and Tom Jensen jr has signed the bottom of the base.", "2010-06-01 08:08:00", 0)

        IE(oC, 450, "LS LOC", "Traction Engine", "1981", "Dauntless", "http://dauntless-steam-engines.webs.com/ ", 3, "This engine was made in Basel Switzerland in 1981", "2010-06-01 08:13:00", 0)

        IE(oC, 451, "Mamod", "SE1A", "1978", "Spokesman", "http://spokessmann.tripod.com/index.html", 4, "This iteration of the simple SE1a represents the last version that could be bought. It exhibits a sight glass boiler and solid fuel burner tray. This engine actually dates from September 1978 and is possible one of the last made, it has never been steamed.", "2010-06-01 20:15:00", 0)

        IE(oC, 452, "Wilesco", "D16", "late 1960s - early 70s", "27ace27", "http://www.thesteamchest.yolasite.com", 4, "My second engine ever purchased, it was very dirty, and still is quite rusty. I am thinking of doing a repaint sometime in the future, but I kind of like it. Check the website for the restoration page, restoration was made possible by some a very kind member of The Unofficial Mamod and Other Steam Forum who cast me some crucial parts. Once running, this engine is truly a beast, it can power anything I can throw at it! at full throttle, it just hums.", "2010-06-14 20:30:00", 0)

        IE(oC, 453, "Steamco", "STC-03", "1996", "Richard Lawson", "", 1, "Mint condition with original box and carrying bag.", "2010-06-15 08:05:00", 0)

        IE(oC, 454, "Mamod", "SE2A", "1978", "Robertosala", "", 6, "This is an example of a late SE2a. Note the sight glass assembly on the boiler's face. The sight glass feature started to replace the overfill plug in all Mamod steam engines back in 1978. The most common SE2a model are the ones that have overfill plug. It is quite rare to find SE2a's with a sight glass assembly. Enjoy the pictures. ", "2010-06-19 12:05:00", 0)

        IE(oC, 455, "SIM Co", "No.50 Watt Senior", "1950-52", "Robert Howe", "", 2, "Unit is fully operational, includes original cloth cord and instruction sheet; all parts in place but has steam leak at cylinder valve and the boiler is dented at the whistle.  Sightglass has minor leak at bottom fixture.   ", "2010-06-24 09:17:00", 0)

        IE(oC, 456, "Jensen", "Jensen #45 (Modified)", "1952-55", "Vic", "http://www.freewebs.com/isettasteam/", 1, "This engine was originally in the 'UNKNOWN' section,  but two of the sites visitors managed to identify it! <br> <br>'Roberto' Writes: I was browsing the rest of the Steam Toy Bible web site and found an 'unknown' category. Well, I can tell that the first engine called only 'unknown' is a modified Jensen style 45 just like the one I submitted months ago. All electric material has been removed, leaving only the boiler, crank, flywheel and piston. They modified the AC cable connector opening by widening it a lot in order to accept a burner. With the electric heater removed, you can use the empty space to put a burner in there and use it as a heat source. The Jensen 45 engine is a normal oscillating cylinder vertical boiler engine. Yes, it will run perfectly. They did a color change to green. Looks nice though. Too bad there is no picture of the other side (as the sight glass is in there but can not be seen in the picture). The whistle and SV have the same thread (like in all Jensens) and can be swapped. In this case, you can see that the SV is using the normal position where the whistle should go and vice-verse. One last thing I can say is that this unknown engine is not made of brass. It is a Jensen 45 with a boiler made of steel which are much more common. You can test it with a magnet. The smoke stack is an original Jensen one but painted in a different color. Please take a look at my pictures of my Jensen 45 you have in your site to compare. Mine has got a brass boiler so it has rivets holding together the steel firebox (where the electric heater is located) and the brass boiler. Regarding year of manufacture: Jensen made the 45 from 1952 to 1955. During the Korean war, brass was scarce as it was used for ammo shells. During the first years of the war, Jensen made them with brass boilers. Later, Mr. Jensen sr. started to use steel and no more brass was available. Steel versions of this engine are very common. Brass ones are very rare. Steel, heat and water is not a good combination. This engines use to fail quickly as they rusted inside and pin holes started to develop inside the bottom of the boiler. Water the will go into the heater rendering unusable and unsafe. For sure this is what happened to this engine and the owner modified it to use a meths burner and keep using it. Very clever modification. <br><br> 27Ace27 also offers the same opinion: The first unknown engine in the unknown manufacturers page on you site is a repainted Jensen 45 that has had the heater removed, and a hole cut in the firebox for a burner. I hope this helps", "2010-06-27 21:50:00", 0)

        IE(oC, 457, "Fleischmann", "120-2", "c1954/1956", "27ace27", "http://www.thesteamchest.yolasite.com", 6, "This engine came on a bargain from Ebay, I can't recall exactly how much I payed for it, but I'm certain it was less than $40. A bargain in all respects, especially considering the fact that it has the all imortant chimney and burner. It even had the original box, instructions, and funnel! It did not come with a whistle, but I have since sourced one, and it is a sweet little runner, and all I did to it was give it a polish! I have only run it once since I don't have any proper Esbit. If you'd like to send me some, by all means, please do! But this engine is so small that securing the fittings makes me nervous.I'm afraid I'll break them! see it running here:  <a href='http://www.youtube.com/watch?v=CqOjwp4hzWI'>You Tube Video</a>", "2010-08-05 18:13:00", 0)

        IE(oC, 458, "Major Toy", "Red Injun", "c1940s", "27ace27", "http://www.thesteamchest.yolasite.com", 6, "This engine was purchased as a mystery engine off of ebay. when it arrived, I noticed the markings ""Red Injun"" just underneath the opening for fuel. I googled it, and came up with an engine that looked mostly the same, except for the cast base and the flywheel spokes are all the way through. (The flywheel also has a hole in it.) The engine frame is part of the cast base, and is some sort of alloy. it is not magnetic. I cannot remember off the top of my head whether it is single or double acting, and the engine is lost in my closet, so perhaps we'll never know! The boiler is nickel plated steel, but it not rusted all the way through. The SV is brass, but when i got it it was totally knackered, the spring and retaining pin had rusted away. and it still is! I have done nothing with this engine since I got it. I'm thinking about replacing the steel boiler with an identical brass one and repainting it, but those plans have yet to take off. for now, this engine is simply a display item. I have since seen one identical engine on ebay, albeit in much better condition and with a stack, and I kindly asked the seller to take a picture of the SV for me, but he was simply too lazy to do so and told me to buy it if I wanted to see it.", "2010-08-05 18:25:00", 0)

        IE(oC, 459, "Peake Engines", "Major", "2009", "Swift Fox", "http://swiftfoxsteamco.webs.com/", 2, "This engine is made by talented Australian Ben Peake in his small workshop and he has made several different models, each engine is certificated and signed by Ben and mine is number 27. <a href='http://peake-engines.com/'>Visit Peake Engines</a>", "2010-08-08 09:00:00", 0)

        IE(oC, 460, "Wilesco", "M88", "2010", "Jacques", "", 1, "Wilesco steam engine accessory with working water pump.", "2010-08-08 09:19:00", 0)

        IE(oC, 461, "Peake Engines", "Minor", "2009", "Unknown", "", 3, "This is the smallest and probably most popular engine that Ben makes in his workshop and is the baby brother to the Major, this one also comes with a certificate and I have no 60. I have included a picture against a Mamod Minor 1 to give a sense of scale. <a href='http://peake-engines.com/'>Visit Peake Engines</a>", "2010-08-08 09:30:00", 0)

        IE(oC, 462, "Kontax", "KS90 Solar", "2010", "Swift Fox", "http://swiftfoxsteamco.webs.com/", 3, "This fine Stirling engine is made in the UK by Kontax Engineering Ltd and is a low temperature example which is able to use a wide variety of heat sources including the sun. I currently have this engine running on top of my wireless modem.  <a href='http://www.stirlingengine.co.uk/'>Manufucturer's Site</a>", "2010-08-30 10:34:00", 0)

        IE(oC, 463, "Wells", "Twin Piston Chain Drive Traction Engine", "1970s", "Phil Morgan", "", 3, "This is the only TWIN piston CHAIN DRIVE Kenneth Wells engine i have seen and after asking many steam fans none of them has seen one of these models with Twin Piston and Chain Drive...", "2010-08-30 10:42:00", 0)

        IE(oC, 464, "Wilesco", "M51", "2009", "Jacques", "", 2, "Wilesco drill press steam engine accessory.", "2010-08-30 10:45:00", 0)

        IE(oC, 465, "Wilesco", "M53", "2009", "Jacques", "", 2, "Wilesco circular saw steam engine accessory.", "2010-08-30 10:46:00", 0)

        IE(oC, 466, "Jensen", "Jensen #60", "Unknown", "Jacques", "", 6, "The factory built version of the model 76. A simple oscillating single.", "2010-09-15 11:30:00", 0)

        IE(oC, 467, "Philcraft", "Jenny Wren", "2010", "Swift Fox", "http://swiftfoxsteamco.webs.com/", 5, "These miniature marvels are made by Phil Gravett and have to be one of the smallest steam engines commercially available. It is the smallest engine of my collection and is even smaller than my Ben Peake Minor which I have added a picture of it beside to give you an indication to just how tiny this engine really is.", "2010-09-15 14:03:00", 0)

        IE(oC, 468, "Mamod", "SR1A", "1972", "Spokesman", "http://spokessmann.tripod.com/index.html", 3, "This is a plain sided firebox iteration/version from c1972. Is in original condition and comes complete with blue box, promo leaflet and steering extensions. The roller has the (then) new sprung reset whistle.", "2010-09-22 08:20:00", 0)

        IE(oC, 469, "Wilesco", "M55", "2009", "Jacques", "", 3, "Wilesco Lineshaft. A line/transmission shaft allowing you to drive multiple accessories or to change speed/power ratios from a model steam engine or small electric motor.", "2010-09-22 08:25:00", 0)

        IE(oC, 470, "Empire", "43", "Mid 1950s", "Dean Williams", "http://www.deansphotographica.com/machining/projects/projects.html", 4, "This is an Empire No. 43 engine.  I realize there is an Empire model called 'B43', but this engine is clearly different.  The plate on the bottom of the base is marked 'Empire, The MetalWare Corp, Two Rivers Wisconsin' and 'No. 43' & 'UL Listed'. Unlike the oscillating cylinder engine on the 'B'43, this plain 43 has a completely different engine, being a single acting spool valve type with reversing eccentric. The base is a thick pressed steel plate, and the cylinder platform and main bearings are a one piece unit, again, unlike the two piece unit on the 'B'43.  It's heavily made throughout, with a 1/16"" thick cylinder shell, cast brass cylinder and steam chest, and heavy cast iron flywheel.  It's a stellar runner, with an impressively loud whistle! This particular toy steam plant needed needed a fair bit of soldering work to put it into good running shape, since someone had heated it dry, and solder had run out the end cap and the safety valve bushing.  Other than that it was in nice shape.", "2010-09-22 08:31:00", 0)

        IE(oC, 471, "Weeden", "43", "1945-1952", "Dean Williams", "http://www.deansphotographica.com/machining/projects/projects.html", 5, "<p>Has a thin sheet metal firebox.  The cylinder is single acting and made from a lead casting.  Similarly, the flywheel is a lead casting.  Just going from the OD of the cylinder, I would guess the bore to be close to 7/16’, and measuring from the center of the flywheel to the crank pin indicates a stroke of 5/8’.  </p> <p>The boiler is brass seamless tubing of approximately .032’ wall thickness.  The heating element is a cartridge type, and though only 250 watts, heats water to steam in just a few minutes.  The heating cartridge slips into a tube that is soldered lengthwise inside the boiler.  The cloth covered cord shows a UL listing on a pinch band fastened to the cord.  </p> <p>I did quite a bit of restoration work on this, including some boiler leaks, a new steam pipe, base sanding and refinishing. Although the firebox shows a few spots of paint loss, it was left in original condition, as I doubt I would be able to match the paint.   </p> <p>It's a very mild runner.  Kind of slow, maybe 600 rpm tops, and doesn't have a lot of power, but it is quite relaxing as it runs very smooth and quiet, and will happily run for as long as you care to keep filling the boiler. I think the stack on this one is slightly short.  Maybe would have been about an inch longer, originally. </p>", "2010-09-22 18:37:00", 0)

        IE(oC, 472, "Doll", "368-1", "1930s", "Franco", "", 1, "", "2010-09-29 18:53:00", 0)

        IE(oC, 473, "Doll", "368-2", "1930s", "Franco", "", 1, "", "2010-09-29 18:54:00", 0)

        IE(oC, 474, "Doll", "368-3", "1930s", "Franco", "", 1, "", "2010-09-29 18:55:00", 0)

        IE(oC, 475, "Doll", "Unknown", "1930s", "Franco", "", 1, "", "2010-09-29 18:56:00", 0)

        IE(oC, 476, "Doll", "364-1", "1930s", "Franco", "", 1, "", "2010-09-29 18:57:00", 0)

        IE(oC, 477, "Doll", "364-2", "1930s", "Franco", "", 1, "", "2010-09-29 18:58:00", 0)

        IE(oC, 478, "Mamod", "SE1", "1946", "Spokesman", "http://spokessmann.tripod.com/index.html", 3, "Very early post-war SE1 exhibiting the short-lived base-mounted chimney. Presented in entirely original condition. The SE1 soon adopted a loco-style chimney as 1946 progressed.", "2010-10-03 10:35:00", 206)

        IE(oC, 479, "Sussex Steam", "Newcomen Atmospheric", "2009", "Roly Williams", "http://rolywilliams.com/", 1, "A well built stationary with several unusual design features.", "2010-10-03 10:41:00", 0)

        IE(oC, 480, "GPM", "D1.5", "c1980s", "Roly Williams", "http://rolywilliams.com/GPM_D1.5.html", 1, "", "2010-10-03 10:50:00", 0)

        IE(oC, 481, "Philcraft", "Lilliput Horizontal", "2010", "Swift Fox", "http://swiftfoxsteamco.webs.com/", 5, "This charming miniature overtype is made by Phil Gravett and uses a lot of the same parts as the Jenny Wren. Unusual for a horizontal boiler, the chimney is a flue which passes vertically through the boiler letting hot gases escape through the chimney. The newer Lilliput’s feature a steam dome that is also fitted to the beam engine plant and marine engine although it is non functioning and is used as a filler plug for the water.", "2010-10-03 10:55:00", 0)

        IE(oC, 482, "Bowman", "234", "approx 1925", "Silver Fox Steam", "", 3, "Bowman 234 4-4-0 Tender Locomotive.<br> An unrestored example of Bowman's largest loco, this one in red LMS livery. The plain connecting rods indicate that it is of relatively early manufacture. The sharp-eyed may notice a missing tender axle, this will be replaced in due course!", "2010-10-04 19:15:00", 0)

        IE(oC, 483, "Multum", "Fan", "1960s", "Jacques", "", 1, "A fan that can be driven by electric motor or steam engine.", "2010-10-05 09:38:00", 0)

        IE(oC, 484, "Bing", "10-114-1", "c1925", "Silver Fox Steam", "", 3, "A compact little engine (base is 170mm square), fired by a single wick circular burner. It carries the 'Bing Werke Bavaria' logo on the side of the firebox. ('Bing Werke' being the second Bing company, formed after WW1.) ", "2010-10-05 18:15:00", 0)

        IE(oC, 485, "Doll", "309-1", "c1935", "Silver Fox Steam", "", 1, "A small overtype engine with 'locomotive' style chimney fired by a single wick spirit burner. The burner sits in a cut-out in the base, centrally under the boiler. This is the type of solid, compact unit that may have inspired the later Mamod MM series engines. Lovely pressed 'brick-effect' firebox. ", "2010-10-08 08:25:00", 0)

        IE(oC, 486, "Doll", "310-5", "c1930", "Silver Fox Steam", "", 4, "A vertical engine, generally termed a 'candlestick'!  This is an example of the largest of the five '310' series engines. It sports a 'blued' brass boiler and nickel-plated whistle &  cylinder. (There was also a 305 series which were indentical except for the finish on boilers and cylinders - they were polished and laquered.) The engine came with instructions, pourer, filler funnel and burner.", "2010-10-08 08:27:00", 0)

        IE(oC, 487, "Wilesco", "M59", "unknown", "Jacques", "", 3, "M59 Eccentic Press. This press has a very nice feel to it as it is cast metal rather than pressed. the action is very smooth.", "2010-10-13 18:25:00", 0)

        IE(oC, 488, "Wilesco", "M52", "unknown", "Jacques", "", 3, "Grinder. a fair condition grinder, note the older colour scheme", "2010-10-13 18:27:00", 0)

        IE(oC, 489, "Wilesco", "M70", "2008", "Jacques", "", 1, "A litho printed steam driven model carousel.", "2010-10-13 18:29:00", 0)

        IE(oC, 490, "Wilesco", "M63", "unknown", "Jacques", "", 2, "An older concrete mixer. later units have a simpler. less bright colour scheme.", "2010-10-13 18:32:00", 0)

        IE(oC, 491, "Wilesco", "M53", "unknown", "Jacques", "", 1, "An older Table saw, the safety guard has broken off somewhere is this playworn toys life. it is in an older brighter wilesco colour scheme.", "2010-10-13 18:34:00", 0)

        IE(oC, 492, "Cyldon", "13-3", "1946-51", "Spokesman", "http://spokessmann.tripod.com/index.html", 2, "This engine dates from around 1946-51, and was made by Sydney S Bird of Enfield. The engine is a Cyldon 13/3 which was marketed under the 'Vulcan' Brand. It seems the Cyldon brand was used for the electrical equipment and cine reels the company also made.", "2010-10-13 18:36:00", 0)

        IE(oC, 493, "Mamod", "TE1", "1963", "Spokesman", "http://spokessmann.tripod.com/index.html", 2, "A very early TE dating from 1963. Displays nut and bolt construction as well as the early smooth canopy. Boxed and in original condition throughout.", "2010-10-13 18:40:00", 0)

        IE(oC, 494, "Mamod", "SE3", "1978", "Spokesman", "http://spokessmann.tripod.com/index.html", 1, "This SE3 dates from 1978 and is undoubtedly one of the last to be manufactured, why?... this engine features a sight glass as well as a solid fuel burner. The engine is in original full working order.", "2010-10-13 18:42:00", 0)

        IE(oC, 495, "Falk", "463-2", "c1935", "Silver Fox Steam", "", 1, " An unusual and interesting engine. It is finshed in the 'Art Deco' style popular in the period, with blended paint on the chimney and 'smoked' effect on the base. The oscilating cylinder of this overtype engine is enclosed in a casing which hides the movement to give it the appearance of a fixed cylinder engine. This 'trick' was used in Britain by Bowman and soon copied by Bing. Bing was taken over by Falk around this time and what we see here may well be a design resulting from this take over/almalgamation. Unfortunately it carries no trademark, not unusual for items made for export at a time when the source was not the most popular in Europe!", "2010-10-13 18:49:00", 0)

        IE(oC, 496, "Marklin", "4095-4", "c1930", "Silver Fox Steam", "", 4, " A medium-sized engine from Marklin, the German maker based in Goppinggen (Wurttemberg). It has the very characteristic Marklin nickel-plated whistle, unique chimney style and the blended paint and smoke-effect on the base. The engine is reciprocating, single-acting and reversable (by slip eccentric). The oil pot in the steam feed is stamped 'OEL' - rather archaic German for 'oil'! The boiler has a water tube gauge glass and is fired by a single wick spirit burner. However, perhaps the most interesting aspect of this engine is the engine frame. Look closely and you may be reminded of some later, British-build engines. In conversation between the owner and Mr Steve Malins, it was confirmed that his father, Mr Geoffery Malins, saw an example of this Marklin frame and copied it for the SE series of Mamod engines from c1950!", "2010-10-13 18:55:00", 0)

        IE(oC, 497, "Mersey Model Co Ltd", "Bench Saw", "1935-40", "Silver Fox Steam", "", 6, "In the very short time they existed, Mersey made a range of quite exquisite engines. In keeping with other manufacturers they also made a range of accessories, model worshop tools, that could be run by the engines. The range included a drill, press, grindstone, a rather splendid lathe and this benchsaw. There are quite a number of engines safe in the hands of collectors, but very few of the tools have emerged! I consider this example to be very special indeed. ", "2010-10-13 18:57:00", 0)

        IE(oC, 498, "Fleischmann", "135-2", "c1963", "Franco", "", 1, "", "2010-10-14 08:04:00", 0)

        IE(oC, 499, "Fleischmann", "125-4", "c1965", "Franco", "", 1, "", "2010-10-14 08:05:00", 0)

        IE(oC, 500, "Peake Engines", "LE Minor", "2010", "Unknown", "", 5, "This is a limited edition engine by Ben Peake, only 20 of these engines will ever be made and I am fortunate to own #10. This engine is based on the Minor, although the difference is that it is double acting and the porting has been cleverly concealed into the engine frame by Ben. It also features a glossy black painted flywheel and cylinder and is mounted on a piece of Australian Silver-Oak.<a href='http://peake-engines.com/'>Visit Peake Engines</a>", "2010-10-23 16:49:00", 0)

        IE(oC, 501, "Jensen", "Jensen #60", "1960/1", "Nick", "http://nicksteam.webs.com/", 5, "Very early Jensen 60, likely one of the first. Features that make it different from later 60's include: square cornered base (it's believed Jensen bought bases from Wilesco for these first 60's), overflow screw (instead of sight glass window), copper-plated steel firebox (not painted), and lack of a steam regulator.", "2010-10-23 16:54:00", 0)

        IE(oC, 502, "Stuart Turner", "S-50 Mill Engine", "circa 1960s", "Nick", "http://nicksteam.webs.com/", 5, "", "2010-10-23 16:56:00", 0)

        IE(oC, 503, "H.E. Boucher Mfg Co", "SinglePiston", "1920s if not older", "Nicholas A. Boyes", "Email: boyesreef@yahoo.com", 5, "I  have not been able to find any information on this model, it has an older style boiler and burner than any photos i have found of other models.", "2010-10-31 08:56:00", 0)

        IE(oC, 504, "Peake Engines", "No 1", "2010", "Swift Fox", "http://swiftfoxsteamco.webs.com/", 4, "This is Ben’s first engine to utilise castings in its construction, it also has some other new features such as the rotary valve incorporated into the crankshaft and a working oiler. Like the LE Minor, this engine is a limited edition of 20 engines and I have #3 in the series.<a href='http://peake-engines.com/'>Visit Peake Engines</a>", "2010-11-14 10:02:00", 0)

        IE(oC, 505, "Wilesco", "D40 (Early)", "1975", "Silver Fox Steam", "", 2, "This is an early version of Wilesco's traction engine. It shares the front-end steering arrangement with the D36 roller. Wilesco later altered the design with some detriment to the control!", "2010-11-14 10:09:00", 0)

        IE(oC, 506, "Mersey Model Co Ltd", "53GR", "c1940", "Silver Fox Steam", "", 3, "This lovely engine, model 53, has the additional features of  a geared countershaft ('G') and a reversing lever ('R'). most of the larger Mersey engines were supplied with a matched lineshaft to drive various models.", "2010-11-14 10:06:00", 0)

        IE(oC, 507, "Fleischmann", "122-3", "c1960", "Silver Fox Steam", "", 4, "This is a restored example of this series. The boilers were sometimes 'blued', sometimes polished brass as this engine. The boiler would have had two chromed steel bands around it originally, not to secure it but purely as 'trimming'. The steam pipe would have been nickel plated. The finest thing about this engine is the 'Doll' style engine pedestal, a characteristic design that Fleischmann retained when they 'inherited' the Doll company. There is a detailed picture of the 'Esbit' solid fuel burner.", "2010-11-14 10:21:00", 0)

        IE(oC, 508, "Mamod", "TE1A", "c1972", "Mick Wilde", "http://burntfingers.webs.com/", 2, "This is the second of my TE1A, circa 1972, with Mamod Old Style Whistle, and water plug, plus Mamod canopy with click lock. Steams very well indeed", "2010-11-16 21:38:00", 0)

        IE(oC, 509, "Mamod", "SE2A", "1970-72", "Mick Wilde", "http://burntfingers.webs.com/", 2, "Mamod SE2A, stationary steam engine circa 1970-72, with uncommon push button  whistle.", "2010-11-21 11:25:00", 0)

        IE(oC, 510, "Mamod", "MM1", "c1949", "Mick Wilde", "http://burntfingers.webs.com/", 3, "Mamod Minor 1 raised base disc crank circa 1949 with single wick burner.", "2010-11-24 08:02:00", 0)

        IE(oC, 511, "Scorpion", "Vertical Donkey Engine", "Late 1950s", "Dauntless", "http://dauntless-steam-engines.webs.com/", 2, "", "2010-11-27 12:42:00", 0)

        IE(oC, 512, "Bowman", "E135", "c1922-35", "Mick Wilde", "http://burntfingers.webs.com/", 2, "Bowman E135 (wood base) circa 1922-1935, reasonabley rare and a good steamer too, ", "2010-12-10 18:16:00", 0)

        IE(oC, 513, "Wilesco", "M65", "unknown", "Jacques", "", 3, "Wilesco M65 Planing Machine", "2010-12-10 18:21:00", 0)

        IE(oC, 514, "Bassett Lowke", "Marine engine", "1960s", "Clinton Taylor", "", 1, "", "2010-12-17 19:56:00", 0)

        IE(oC, 515, "Wilesco", "D8", "1950 (Estimated by Wilesco)", "Wim Gregoor (from Arnhem, Holland)", "", 5, "Wilesco D 8 is original and complete / only cleaned and polished / original and first burner, smokestack, whistle/weight, refill plug.  <br> Extra Note: Burner holder of first type, soldered to the bottom.  (original Wilesco bakelite/brass funnel added, as brass bolds on the corners).", "2011-12-22 21:53:00", 0)

        IE(oC, 516, "Wilesco", "D24", "1960s", "Ross", "", 1, "This engine is using a butane/propane gas burner.  The steam exhaust is fed into a condenser/chimney.  It's shown hooked up to a generator.", "2011-01-05 09:45:00", 0)

        IE(oC, 517, "HOG", "Stirling", "2009", "Benchmark", "http://dampmaskiner.webs.com/", 1, "Fine German handcraftsmanship . Complete with a certificate from the gold jewelers association. 24 carat gold plated.", "2011-01-06 15:45:00", 0, "http://www.youtube.com/watch?v=ubFSxqwP5Ig")

        IE(oC, 518, "Marklin", "16051", "2009", "Benchmark", "http://dampmaskiner.webs.com/", 2, "Märklin offered this engine on a 'subscription only' basis, for a period of time (which was extended at least once) between 2004-2005. After the deadline date, no more orders were accepted and production ceased. This is why Märklin claimed it was a 'limited edition'. They were reproductions of the Marklin 4158 Compound that was made from 1911 to 1939.", "2011-01-06 15:55:00", 0, "http://www.youtube.com/watch?v=KIeVDDj7rJg")

        IE(oC, 519, "L.C. Mason", "Minnie 1 Inch Scale", "1985", "Benchmark", "http://dampmaskiner.webs.com/", 4, "Model 'Minnie' built from plans made by L.C Mason originally coal fired but converted to gas to allow for indoor firing.", "2011-01-06 16:00:00", 0, "http://www.youtube.com/watch?v=mGuTe-xsN-o")

        IE(oC, 520, "Mercer", "Type 1", "2005", "Benchmark", "http://dampmaskiner.webs.com/", 1, "D.R. Mercer Type 1 Traction Engine. Can be bought assembled or in kit form. Very smooth runners and powerful for their size.", "2011-01-06 16:07:00", 0, "http://www.youtube.com/watch?v=5h6uAUT5Vsk")

        IE(oC, 521, "Wilesco", "D457", "1980", "Benchmark", "http://dampmaskiner.webs.com/", 2, "Full brass version of the common Wilesco D455 and D456. This model is not manufactured any more (since 2000) hence a desirable item amongst collectors.", "2011-01-06 16:11:00", 0, "http://www.youtube.com/watch?v=31qq1XNhsOo")

        IE(oC, 522, "Wilesco", "D366", "??", "Benchmark", "http://dampmaskiner.webs.com/", 1, "Black and brass version of the D365 roller", "2011-01-06 16:13:00", 0, "")

        IE(oC, 523, "Wilesco", "D32", "1965", "Benchmark", "http://dampmaskiner.webs.com/", 2, "The largest model ever produced, often refered to as the holy grail of all Wilesco models, only produced between 1965 to 1980. Compete with clutch transmission, waterpump and reserve tank. Hard to come by especially the early models with the blue cylinders.", "2011-01-06 16:17:00", 0, "http://www.youtube.com/watch?v=SBamjc9XJP0")

        IE(oC, 524, "Bohm", "HB7", "2009", "Benchmark", "http://dampmaskiner.webs.com/", 2, "", "2011-01-06 16:20:00", 0, "http://www.youtube.com/watch?v=Ssd5d2xkpas")

        IE(oC, 525, "Kleinemeier", "KM Vertical", "2010", "Benchmark", "http://dampmaskiner.webs.com/", 2, "", "2011-01-06 16:24:00", 0, "")

        IE(oC, 526, "Jensen", "Jensen #85", "early?", "Benchmark", "http://dampmaskiner.webs.com/", 2, "A very old example of the Jensen 85, notice the position of the label on the firebox and the unpainted flywheel. These are some of the small differences form the version currently produced.", "2011-01-06 16:30:00", 0, "http://www.youtube.com/watch?v=faQi5aM8G3c")

        IE(oC, 527, "SEL", "1540 Standard", "???", "Benchmark", "http://dampmaskiner.webs.com/", 1, "", "2011-01-06 16:34:00", 0, "http://www.youtube.com/watch?v=KIoWBgNvt7o")

        IE(oC, 528, "Doll", "305-5", "1929", "Benchmark", "http://dampmaskiner.webs.com/", 1, "Doll was one of the early Nuremberg steam manufactures who churned out fine examples of artisan craftsmanship. This is a vertical model of on of Doll's smaller series.", "2011-01-06 16:39:00", 0, "http://www.youtube.com/watch?v=O3P7zNxV8p8")

        IE(oC, 529, "R. Reichelt", "LH", "2002", "Benchmark", "http://dampmaskiner.webs.com/", 2, "R. Reichelt Stirling engine  . The same model has been tested and run continuously from 3 sept 2003 - 18 dec 2005 , more than 20,000 hrs run time!!", "2011-01-08 16:59:00", 0, "http://www.youtube.com/watch?v=50jCFTYy0g4")

        IE(oC, 530, "James Maiwald", "Flame Licker", "2010", "Benchmark", "http://dampmaskiner.webs.com/", 2, " He has numerous designs and the quality of machining is exquisite.", "2011-01-08 17:15:00", 0, "http://www.youtube.com/watch?v=0HDjANH6FoA")

        IE(oC, 531, "EKT", "Workshop", "????", "Benchmark", "http://dampmaskiner.webs.com/", 1, "Originally intended to be instructional school learning aids for technical students, EKT tools are amongst the best quality in the world.", "2011-01-08 17:21:00", 0, "http://www.youtube.com/watch?v=qcWRVQySqas")

        IE(oC, 532, "EKT", "Lathe and Press", "????", "Benchmark", "http://dampmaskiner.webs.com/", 1, "Originally intended to be instructional school learning aids for technical students, EKT tools are amongst the best quality in the world.", "2011-01-08 17:21:00", 0, "http://www.youtube.com/watch?v=qcWRVQySqas")

        IE(oC, 533, "Fleischmann", "Sausage Maker", "????", "Benchmark", "http://dampmaskiner.webs.com/", 1, "", "2011-01-08 17:26:00", 0, "")

        IE(oC, 534, "Fleischmann", "Blacksmith", "????", "Benchmark", "http://dampmaskiner.webs.com/", 1, "", "2011-01-08 17:26:00", 0, "")

        IE(oC, 535, "Fleischmann", "Lineshaft", "????", "Benchmark", "http://dampmaskiner.webs.com/", 1, "", "2011-01-08 17:26:00", 0, "")

        IE(oC, 536, "Tekno-Langes", "Workshop", "1955", "Benchmark", "http://dampmaskiner.webs.com/", 1, "Tekno and Langes merged to produce some models together at some point. The founder of Jensen USA (Thomas Jensen) originally was a danish immigrant  must have still had some ties to his native Denmark as evidenced by his own range of jensen models that bore an unmistakable similarity to the Tekno/Langes Series.", "2011-01-10 21:26:00", 0, "")

        IE(oC, 537, "Tekno-Langes", "Lathe", "1955", "Benchmark", "http://dampmaskiner.webs.com/", 1, "Tekno and Langes merged to produce some models together at some point. The founder of Jensen USA (Thomas Jensen) originally was a danish immigrant  must have still had some ties to his native Denmark as evidenced by his own range of jensen models that bore an unmistakable similarity to the Tekno/Langes Series.", "2011-01-10 21:26:00", 0, "")

        IE(oC, 538, "Tekno-Langes", "Dynamo", "1955", "Benchmark", "http://dampmaskiner.webs.com/", 1, "Tekno and Langes merged to produce some models together at some point. The founder of Jensen USA (Thomas Jensen) originally was a danish immigrant  must have still had some ties to his native Denmark as evidenced by his own range of jensen models that bore an unmistakable similarity to the Tekno/Langes Series.", "2011-01-10 21:26:00", 0, "")

        IE(oC, 539, "James Maiwald", "Flame Licker Twin", "2010", "None", "", 3, "A unique twin cylinder vacuum engine made by James Maiwald in Germany.", "2011-01-11 15:57:00", 0)

        IE(oC, 540, "Peake Engines", "No. 2", "2010", "Swift Fox", "http://swiftfoxsteamco.webs.com/", 4, "The Peake No 2 is Ben’s second engine to be made from castings and the first to feature a  ‘S’ spoke flywheel and all metal construction, it shares a similar design of piston/connecting rod as the Peake 1 but mounted in an upside down configuration. It is a limited edition of 25 engines.", "2011-01-29 10:15:00", 0)

        IE(oC, 541, "Philcraft", "Jenny Wren (Custom)", "2011", "Swift Fox", "http://swiftfoxsteamco.webs.com/", 3, "This is a customised version of the standard Jenny Wren made by Philcraft, the notable differences are: exhaust to chimney, boiler cladding and a chemically painted firebox. As well as improving the appearance of the engine, these are functional improvements to the existing design.", "2011-02-09 21:25:00", 0)

        IE(oC, 542, "Fleischmann", "120-4", "1965", "Benchmark", "http://dampmaskiner.webs.com", 2, "", "2011-03-10 07:45:00", 0, "")

        IE(oC, 543, "Stuart Turner", "Sun", "???", "Benchmark", "http://dampmaskiner.webs.com", 3, "A very rare and popular engine among boat enthusiasts. Used extensively on RC hydroplane models due to its high RPM performing abilities.", "2011-03-10 07:52:00", 0, "http://www.youtube.com/watch?v=eiZQizefAlQ")

        IE(oC, 544, "Bohm", "HB10", "???", "Benchmark", "http://dampmaskiner.webs.com", 2, "", "2011-03-10 07:54:00", 0, "http://www.youtube.com/watch?v=XxQ_7jXXiPo")

        IE(oC, 545, "Bing", "130-51", "???", "Benchmark", "http://dampmaskiner.webs.com", 2, "This engine has now been identified as a 130/51", "2011-03-10 07:58:00", 0, "")

        IE(oC, 546, "Doll", "511", "1927-1937", "Benchmark", "http://dampmaskiner.webs.com", 2, "", "2011-03-10 07:59:00", 0, "http://www.youtube.com/watch?v=GfqbIv6EATM")

        IE(oC, 547, "Doll", "Vertical", "???", "Benchmark", "http://dampmaskiner.webs.com", 3, "", "2011-03-10 08:03:00", 0, "")

        IE(oC, 548, "Plank", "425", "???", "Benchmark", "http://dampmaskiner.webs.com", 2, "Ernst Plank also made stationary models and magic lanterns. The company was founded in 1866 and was one of the earliest builders of model steam engines. Schaller brothers purchased the company in 1935.", "2011-03-11 14:28:00", 0, "http://www.youtube.com/watch?v=1eD9kINJY08")

        IE(oC, 549, "HSM", "York Bolton", "2005", "Benchmark", "http://dampmaskiner.webs.com", 3, "A very detailed and amazingly correct steam plant , originally manufactured by 'Historic steam models' but production has since stopped . Getting increasingly harder to find these days.", "2011-03-27 09:50:00", 0, "http://www.youtube.com/watch?v=4IhsLmX6HG4")

        IE(oC, 550, "Wilesco", "D377", "???", "alan_donna", "", 1, "Kit Built Version", "2011-03-26 17:42:00", 0, "")

        IE(oC, 551, "Gem", "Stationary", "1940s-1950s", "Spokesman", "http://spokessmann.tripod.com/index.html", 3, "A GEM stationary made sometime around late 1940s/early 1950s by GEM Steam and Electric Toys of Trowbridge, Wiltshire. Engine is in original condition. A marine engine very similar to this stationary was also made.", "2011-03-27 09:56:00", 0)

        IE(oC, 552, "Peake Engines", "Micro", "2011", "Unknown", "", 4, "This is the smallest engine so far to come out of the Peake workshop, it is a very tiny single acting oscillating engine in a vertical configuration. It comes in a nice gift box along with a tiny certificate and manual, Ben also made an alternative flywheel as a gift for the first ten purchasers.", "2011-03-27 10:02:00", 0)

        IE(oC, 553, "Philcraft", "Beam Engine", "1994", "Roly Williams", "http://rolywilliams.com/philcraft_boilerless_beam_engine.html", 1, "Beam engine without the optional boiler and stand but with the optional glass dome. ", "2011-06-18 14:42:00", 0)

        IE(oC, 554, "Wilesco", "M61 Forge Hammer", "Mid 90s", "Daloof (Markus)", "", 1, "", "2011-06-18 14:51:00", 0)

        IE(oC, 555, "Wilesco", "D4", "", "Daloof (Markus)", "", 3, "", "2011-06-18 14:51:00", 0)

        IE(oC, 556, "Wilesco", "D5", "", "Daloof (Markus)", "", 3, "", "2011-06-18 14:53:00", 0)

        IE(oC, 557, "Wilesco", "D6", "", "Daloof (Markus)", "", 3, "", "2011-06-18 14:55:00", 0)

        IE(oC, 558, "Wilesco", "D16", "", "Daloof (Markus)", "", 3, "New boiler is on order from Germany!", "2011-06-18 14:56:00", 0)

        IE(oC, 559, "Stuart Turner", "Sirius", "???", "Benchmark", "http://dampmaskiner.webs.com", 3, "Fully-enclosed cast-iron crankcase , light cast iron pistons with stainless steel piston valve. Stuart claimed 0.4 bhp at 2800 rpm on 80 psi superheated steam. This engine was used during the war by paratroopers and was hardy enough to be air dropped for charging the radioman's batteries. After the war it enjoyed much success in flash steam hydroplane racing.", "2011-06-27 08:11:00", 0, "http://www.youtube.com/watch?v=oEH99bIBkJs")

        IE(oC, 560, "Stuart Turner", "501 Boiler", "???", "Benchmark", "http://dampmaskiner.webs.com", 2, "501 Babcock Boiiler.", "2011-06-27 08:14:00", 0, "")

        IE(oC, 561, "Stuart Turner", "504 Boiler", "???", "Benchmark", "http://dampmaskiner.webs.com", 3, "504 Babcock Boiiler.", "2011-06-27 08:17:00", 0, "")

        IE(oC, 562, "Hornby", "Mallard", "2005", "Benchmark", "http://dampmaskiner.webs.com", 1, "Hornby Mallard Live Steam Locomotive <a href='http://www.youtube.com/watch?v=RyH5dUEp4r8'>Another video</a>", "2011-06-30 07:50:00", 0, "http://www.youtube.com/watch?v=XgYPzJpcQiI")

        IE(oC, 563, "Hielscher", "Steam Cottage Kate", "2010", "Benchmark", "http://dampmaskiner.webs.com", 2, "Made in Germany by the company 'Hielscher Dampfmodelle' owned by Lutz Hielscher. An interesting line of his own patent designs. <a href='http://www.hielscher-dampfmodelle.de'> Company Website</a>", "2011-06-30 07:55:00", 0, "http://www.youtube.com/watch?v=2IsdtS6Z8GA")

        IE(oC, 564, "Hielscher", "Steam Roller", "2009", "Benchmark", "http://dampmaskiner.webs.com", 2, "Made in Germany by the company 'Hielscher Dampfmodelle' owned by Lutz Hielscher. An interesting line of his own patent designs. <a href='http://www.hielscher-dampfmodelle.de'> Company Website</a>", "2011-06-30 08:00:00", 0, "http://www.youtube.com/watch?v=8zghmveGqfU")

        IE(oC, 565, "JC-Steam", "Proteus Turbine", "2000s", "Benchmark", "http://dampmaskiner.webs.com", 2, "This amazing piece of engineering is made in France by JC Steam and is their first series of steam turbines", "2011-06-30 08:10:00", 0, "http://www.youtube.com/watch?v=qifaCBjEq1A")

        IE(oC, 566, "Unknown", "Unknown-2", "???", "Greg-M", "", 4, "A query on this engine 'I was just given the steam motor in the attached pictures and don't know anything about it. According to the guys sister who is now 60 her brother got it from their mothers estate. Reportedly if you connect air to it still runs perfectly. It appears to be machined very well and has a spindle on the main flywheel that supplied power to something.  There are no castings or names anywhere that I could find. Any clue what this is, how old it is, where it was made etc.?'", "2011-06-30 08:21:00", 0, "")

        IE(oC, 567, "Liney Machine", "Thimble", "2011", "Benchmark", "http://dampmaskiner.webs.com", 2, "This Liney Thimble kit was put together by Dean in the USA", "2011-06-30 08:15:00", 0, "http://www.youtube.com/watch?v=mCxFdgX5Gjg")

        IE(oC, 568, "Mamod", "Quobble (SE3 Mod)", "2009-2011", "Stilldrillin", "http://www.youtube.com/user/Dayjo9", 3, "This is a modified SE3 to double the number of cylinders and is christened 'Quobble' by it's creator.  It is self starting and is able to run from the steam of the standard boiler.  See the build log <a href='http://modelsteam.myfreeforum.org/ftopic21812-0-asc-0.php'> here </a> which has all the details.", "2011-07-04 18:15:00", 0, "http://www.youtube.com/watch?v=Dq1xPuUYBSw")

        IE(oC, 569, "Hielscher", "Trike", "???", "Benchmark", "http://dampmaskiner.webs.com", 2, "Made in Germany by the company 'Hielscher Dampfmodelle' owned by Lutz Hielscher. An interesting line of his own patent designs. <a href='http://www.hielscher-dampfmodelle.de'> Company Website</a>", "2011-07-17 10:46:00", 0, "")

        IE(oC, 570, "Stuart Turner", "Beam Engine", "???", "Benchmark", "http://dampmaskiner.webs.com", 2, "The Stuart beam engine is a highly desired model amongst steam collectors. This engine is modelled after the old British pumping station beam engines. ", "2011-07-17 10:49:00", 0, "http://www.youtube.com/watch?v=RMnBzBJmos8")

        IE(oC, 571, "Cotswold Heritage", "Perseus Mill Engine", "???", "Benchmark", "http://dampmaskiner.webs.com", 3, "", "2011-07-17 10:53:00", 0, "http://www.youtube.com/watch?v=SAWQRDCQP_I")

        IE(oC, 572, "Cotswold Heritage", "2HRFP Boilder", "???", "Benchmark", "http://dampmaskiner.webs.com", 3, "", "2011-07-17 10:58:00", 0, "http://www.youtube.com/watch?v=SAWQRDCQP_I")

        IE(oC, 573, "Cotswold Heritage", "McOnies Engine", "???", "Benchmark", "http://dampmaskiner.webs.com", 3, "A beautiful model of the authentic steam engine by the once Glasgow based engineering firm of W & A McOnie that drove the sugar mills at the Sugar cane plantations of the then British Caribbean Ca. 1888.  Complete with a working a water pump, 20cm flywheel, steam governor and much more.", "2011-07-17 10:58:00", 0, "http://www.youtube.com/watch?v=IzxlKeCpupA&NR=1")

        IE(oC, 574, "Unknown", "Unknown 4", "???", "Toby Caunt", "", 2, "I have no idea what engine this is but may be a bing. it has no model stickers or makers badges or could it be a home made engine. <p> Feedback recieved from Pete King: Reference TSB Entry 574, owner Toby Caunt. Although I cannot give you a maker's name, these engines are made in Britain by an individual and normally have a sticker on them stating 'Made in Great Britain' and also displaying a Union Jack. I have a very similar engine but without the chimney/condensator. The person who makes them sells them on ebay, which is where I purchased mine from. Unforunately he does not have any on offer at the moment or I could tell you where he is based. Because I purchased mine a few years ago I have not been able to find the paperwork but if I do manage to uncover any further info I will let you know.</p>  Update:   Made in the UK by ebay seller stephens6949 based in Congleton (Real name: Steve Smith)", "2012-01-02 12:14:00", 0, "")

        IE(oC, 575, "Mamod", "Centurion", "2011", "Patty", "http://www.PattysMiniatureWorld.co.uk", 1, "I made the tyres myself and painted the stripes on the wheels. ", "2011-07-17 11:16:00", 0, "")

        IE(oC, 576, "Midwest", "Elliot Bay Steam Launch", "2004", "Patty", "http://www.PattysMiniatureWorld.co.uk", 1, "It’s an 'Elliot Bay Steam Launch - Kit # 988'", "2011-07-17 11:22:00", 0, "")

        IE(oC, 577, "Mamod", "SE3", "1950s", "Patty", "http://www.PattysMiniatureWorld.co.uk", 1, "", "2011-07-17 18:10:00", 0, "")

        IE(oC, 578, "Bowman", "M175", "c1933", "Spokesman", "http://spokessmann.tripod.com/index.html", 2, "The second smallest Bowman made. Slight larger than the M180. Presented in playworn condition.", "2011-07-20 08:26:00", 0)

        IE(oC, 579, "Burnac", "Vulcan", "c1946-49", "Spokesman", "http://spokessmann.tripod.com/index.html", 2, "This handsome British vertical feature a brass boiler and copper top plate. Exhibits the non-Bing sight glass assembly, which is simpler in design.  Presented in playworn condition. Show with another Burnac showing the 'Bing' type sigh glass assembly.", "2011-07-20 08:29:00", 0)

        ' Duplicate! IE(oC, 580, "Mamod", "TE1", "1963", "Spokesman", "http://spokessmann.tripod.com/index.html", 2, "A superb example of this sought after engine, showing early smooth canopy and screw construction. Presented in original playworn condition.", "2011-07-20 08:32:00", 0)

        IE(oC, 581, "Mamod", "TE1A", "1973", "Spokesman", "http://spokessmann.tripod.com/index.html", 2, "This is a mint unfired example from the heyday of Malins engineers in 70s. Boxed and complete with all inner packaging.", "2011-07-20 08:35:00", 0)

        IE(oC, 582, "Philcraft", "Marine Engine", "2011", "Swift Fox", "http://swiftfoxsteamco.webs.com/", 3, "This is the v- twin marine engine by Philcraft, it is almost identical to Roly Williams example above apart from the new addition of a needle valve to regulate gas to the burner more effectively, this should give the user much finer control of the engine speed and steam generation in the boiler than the previous system that was used.", "2011-07-23 12:48:00", 0)

        IE(oC, 583, "Cranko", "Mogul", "c1950", "Colin Duthie", "", 2, " Made about 1950. Note cranks on front driving wheel axles to convert the 180 degree timing of the oscillating cylinders to 270/90 degree quartering so all six wheels are powered. `0` gauge.  Four wick burner under boiler.  The second photo is an image from the Cranko catalouge.", "2011-08-06 08:15:00", 0)

        IE(oC, 584, "Cranko", "Mighty Atom", "c1950-1957", "Colin Duthie", "", 2, "Photo of Cranko Mighty Atom herewith.   With Cranko wagons.   This loco replaced the earlier front cylindered four wheel loco.  Mighty Atom is simpler, has a single cylinder in the cab.   Not realistic in appearance but a good runner.  Made from about 1950 until production ceased approximately 1956  or 1957.  Returned Servicemen`s League intended to continue production but this did not happen.", "2011-08-06 08:19:00", 0)

        IE(oC, 585, "David Auld", "Locomotive", "c1966-1989", "TrademeNZAuction", "", 9, "These photos are of a very rare engine and track made by David Auld. David Auld made 130 of these locos, plus 27 more slightly different. Also earlier there was a run of 20 of a different design. The track was made after Lawrence Lines stopped production, it is Lawrence track without the trademark. His 0 gauge steam loco production lasted about from 1966 until 1989, or so.  The track make a circle 1.3 Metres wide.  These rare pictures appeared on the Trademe NZ auction website.", "2011-08-06 08:22:00", 0)

        IE(oC, 586, "David Auld", "Locomotive (Front Cylinder)", "c1966", "Colin Duthie", "", 1, "David Auld first type locomotive. 0 gauge. Front cylinders, non-reversing. Made about 1966, only 20 made for retail sale, so rare.", "2011-08-08 19:13:00", 0)

        IE(oC, 587, "David Auld", "Locomotive (Rear Cylinder)", "c1990", "Colin Duthie", "", 1, "  David Auld locos of the rear cylinder type.  The newer one is of the final batch of 27 locos and is the actual last loco David Auld sold. (this was in 1990). This loco has the square section outer cylinder housing.   These locos are reversible. ", "2011-08-08 19:15:00", 0)

        IE(oC, 588, "Bing", "Superforce Locomotive", "c1926", "Colin Duthie", "", 1, "Small Bing `superforce` locomotive made about 1926.   The single cylinder and flywheel can be seen in the cab.   A smooth and steady runner.  A quaint thing is that one side of the cab is letterred `London Midland Scottish` but the other side has `London Midland Schottish`. The Germans made a minor error!", "2011-08-11 12:45:00", 0)

        IE(oC, 589, "Unknown", "Unknown 5", "1900s", "Colin Duthie", "", 1, "Unknown make of vertical boiler steam engine.  Probably a cheaper German type. ", "2011-08-11 12:48:00", 0)

        IE(oC, 590, "Mersey Model Co Ltd", "54R", "1938", "MooseMan", "http://www.MooseMan.org.uk/", 1, "Mersey’s twin model, with vertically arranged engine. There is another version with horizontally opposed pistons and cylinders.", "2011-08-14 09:28:00", 0)

        IE(oC, 591, "Fleischmann", "105-1", "1954", "Robertosala", "", 2, "", "2011-08-28 10:34:00", 0)

        IE(oC, 592, "Fleischmann", "122-4", "1963", "Robertosala", "", 4, "", "2011-08-28 10:36:00", 0)

        IE(oC, 593, "Jensen", "Jensen #55", "1970", "Robertosala", "", 4, "Jensen Manufacturing Co. Still produces this model.  During the 70s, they started painting their fireboxes in salmon color.", "2011-08-28 10:38:00", 0)

        IE(oC, 594, "Jensen", "Jensen #70", "1973", "Robertosala", "", 4, "Jensen Manufacturing Co. Still produces this model.  During the 70s, they started painting their fireboxes in salmon color.", "2011-08-28 10:40:00", 0)

        IE(oC, 595, "Jensen", "Jensen #75", "1972", "Robertosala", "", 4, "Jensen Manufacturing Co. Still produces this model.  During the 70s, they started painting their fireboxes in salmon color.", "2011-08-28 10:44:00", 0)

        IE(oC, 596, "Mamod", "SP4", "c1980", "Roly Williams", "http://rolywilliams.com/mamod_sp4.html", 1, "Special black and white limited edition livery.", "2011-09-12 08:06:00", 0)

        IE(oC, 597, "Peake Engines", "No 3", "2011", "Roly Williams", "http://rolywilliams.com/ben_peak_no3.html", 2, "", "2011-09-12 08:12:00", 0)

        IE(oC, 598, "Unknown", "Bittlestone", "c2011", "Roly Williams", "http://rolywilliams.com/chronos_vertical.html", 2, "Unknown make - sold by Chronos in the UK", "2011-09-12 08:16:00", 0)

        IE(oC, 599, "ADE", "Stationary", "c1950", "Roly Williams", "http://rolywilliams.com/ade_stationary.html", 1, "", "2011-09-12 08:18:00", 0)

        IE(oC, 600, "Wilesco", "R200 Atomic Plant", "1960", "Robertosala", "", 6, "Wilesco ran production of these steam engines for a few years. These were available in stores in the period between 1958 and 1968 with very low sales, due to the fact that people was scared of anything with the word 'Atomic' on it, as it was associated with the Atomic Bomb. The Cold War was raging on during those days, the 'Missile Crisis', the Berlin Wall and the arms race between the East and West was the note of the day. Shelters, to survive atomic attacks, were being built in the USA and Europe in preparation for war, in fact, we were this close to have one!  There was nothing wrong, in terms of functionality, safety or quality with this steam engine. It just came out, to the market, on the wrong period in history, so Wilesco quit producing them in short time. Atomic Energy proved to be unpopular at the time.  As of today, they are very scarce and difficult to find in good condition. Usually these are very expensive.  Electrically heated by coil system: 220 VAC for Europe. 115 VAC export versions, like the one shown here, were also manufactured.  Power consumption: 250 Watts.   Steam Engine is based on the Wilesco D10 platform - Stroke 16 mm - Diameter 9 mm - Flywheel 70 mm. ", "2011-09-12 21:40:00", 0)

        IE(oC, 601, "Weeden", "Dart Locomotive", "Unknown 1888+", "Colin Duthie", "", 1, "Made in Boston USA, dates of manufacture not known but Weeden commenced production of live steam locomotives in 1888.", "2011-09-14 08:01:00", 0)

        IE(oC, 602, "Stevens Model Dockyard", "Locomotive", "Unknown", "Colin Duthie", "", 1, "Stevens Model Dockyard made locomotives in London England from the late 1800s until 1920 or so.", "2011-09-14 08:03:00", 0)

        IE(oC, 603, "Eugene Beggs", "Locomotive", "Unknown 1871+", "Colin Duthie", "", 1, "Eugene Beggs of the USA commenced making locomotives from about 1871, and made them well into the 20th century.  Several types were made, with 4.2.0,  2.2.0, 4.2.2., and 4.4.0 wheel arrangements.  These were made in considerable numbers.", "2011-09-14 08:08:00", 0)

        IE(oC, 604, "Mamod", "SR1A", "Approx 2006", "Mamod58", "", 1, "A Forest Classics special with longer boiler and canopy.", "2011-09-25 10:55:00", 0)

        IE(oC, 605, "Mamod", "TE1A", "2008", "Mamod58", "", 1, "A later model of the TE1A.", "2011-09-25 10:58:00", 0)

        IE(oC, 606, "Wilesco", "D10", "2011", "GaryD", "", 6, "This is the latest version of the D10. The main difference is the exhaust steam is now fed out to the chimney. The condenced steam is collected in a small tray at the base of the chimney. Still a well made model and a good runner.", "2011-10-07 17:58:00", 0)

        IE(oC, 607, "Wilesco", "D21", "2009", "GaryD", "", 5, "This is a large engine the base measures 300mm x 350mm. This model has a water injection hand pump, so in theory you can run the engine indefinitely. Water is pumped from a reservoir underneath.  The exhaust steam is fed to the chimney and the condensed water collected at the base. It is equipped with a working steam pressure gauge, drain valve and steam regulator valve. The engine runs nicely at low revs.", "2011-10-16 11:31:00", 0)

        IE(oC, 608, "PREFO", "Base Plate", "Unknown", "Darthvader (Bob)", "", 1, "ART-NO22001", "2011-10-24 08:10:00", 0)

        IE(oC, 609, "PREFO", "Motor", "Unknown", "Darthvader (Bob)", "", 1, "ART-NO22020", "2011-10-24 08:11:00", 0)

        IE(oC, 610, "PREFO", "Line Shaft & Motor", "Unknown", "Darthvader (Bob)", "", 1, "ART-NO22021", "2011-10-24 08:13:00", 0)

        IE(oC, 611, "PREFO", "Metalworking Set", "Unknown", "Darthvader (Bob)", "", 2, "ART-NO SER 1 Metalworking,  Metal working set on Prefo Base", "2011-10-24 08:14:00", 0)

        IE(oC, 612, "PREFO", "Metalworking Lathe", "Unknown", "Darthvader (Bob)", "", 1, "ART-NO 22030", "2011-10-24 08:17:00", 0)

        IE(oC, 613, "PREFO", "Pillar Drill", "Unknown", "Darthvader (Bob)", "", 1, "ART-NO 22040", "2011-10-24 08:18:00", 0)

        IE(oC, 614, "PREFO", "Hacksaw", "Unknown", "Darthvader (Bob)", "", 1, "ART-NO 22050", "2011-10-24 18:18:00", 0)

        IE(oC, 615, "PREFO", "Grinder", "Unknown", "Darthvader (Bob)", "", 2, "ART-NO 22060", "2011-10-24 18:19:00", 0)

        IE(oC, 616, "PREFO", "Woodworking Lathe", "Unknown", "Darthvader (Bob)", "", 2, "ART-NO 22120", "2011-10-24 18:21:00", 0)

        IE(oC, 617, "PREFO", "Planer", "Unknown", "Darthvader (Bob)", "", 1, "ART-NO 22130", "2011-10-24 18:22:00", 0)

        IE(oC, 618, "PREFO", "Bench Saw", "Unknown", "Darthvader (Bob)", "", 1, "ART-NO 22140", "2011-10-24 18:23:00", 0)

        IE(oC, 619, "PREFO", "Woodworking Set", "Unknown", "Darthvader (Bob)", "", 2, "ART-NO Set 2 Woodworking set on a wooden base.", "2011-10-24 18:24:00", 0)

        IE(oC, 620, "Mamod", "FE1 Fire Engine", "???", "Ozsteamdemon", "", 3, "As new condition unfired.", "2011-10-24 18:27:00", 0)

        IE(oC, 621, "Saito", "T3DR", "???", "Ozsteamdemon", "", 5, "Engine model - T3DR 3 Cyl , Reversing.  Boiler(model - B3)  Center-Flue with Superheater   Burner Preheated & Gasified Fuel - Methanol", "2011-10-28 16:17:00", 0)

        IE(oC, 622, "Philcraft", "Beam Engine", "2011", "GaryD", "", 5, "This is Phil Gravet's flagship engine. It is a work of art and a joy to run. ", "2011-10-28 16:23:00", 0)

        IE(oC, 623, "Bing", "8086-1 (believed to be)", "???", "alan_donna", "", 1, "We believe this is an early example of a Bing vertical engine. If anyone has any information on my little engine i would be very greatfull.", "2011-10-28 16:28:00", 0)

        IE(oC, 624, "Latimer Productions", "Plane L5", "approx 1945-50", "Silver Fox Steam", "", 5, "This is a pristine (refurbished) example of the larger of the two engines made by Latimer just after WW2. Very similar in some ways to the Luton Bowman engines of the same period.", "2011-11-19 15:03:00", 0)

        IE(oC, 625, "Fleischmann", "501-1", "circa 1960", "Silver Fox Steam", "", 1, "Made c1960, this is Fleischmann's version of Doll's original compact design of candlestick engine with a through-boiler crankshaft. My example has a replica chimney which is slightly taller than it would have been originally. The engine was provided with a small solid fuel burner tray, just about big enough fo one Esbit tablet! I fire it with a small spirit vapourising burner.", "2011-11-19 15:08:00", 0)

        IE(oC, 626, "Bing", "10-114-2", "circa 1935", "Silver Fox Steam", "", 7, "This is the larger of the two engines in the 10/114 range. Made by Bing after WW1 and prior to the company's demise c1935. It is a single cylinder oscillating engine with a pulley incorporated in the flywheel. Unusually, an exhaust steam pipe is provided. The original burer is missing, but would have been a circular spirit burner similar to the one shown with it's smaller brother, but may have had two wicks. There are some pictures of the two engines together for comparison purposes.", "2011-11-19 15:12:00", 0)

        IE(oC, 627, "Plank", "2000-305", "circa 1910", "Silver Fox Steam", "", 2, "Ernst Plank Candlestick Engine (possibly Model No 2000/305 c 1910) Plank (1866 - 1935) made a wide range of steam engines and had one of the most ornate logos. This is one of their smaller vertical oscillating cylinder engines, fired by a small single wick spirit burner. It has been repaired by the addition of some small nuts & bolts to replace broken tabs and a new handle for the whistle. The base and engine frame have been repainted close to the original colours.", "2011-11-19 15:16:00", 0)

        IE(oC, 628, "Kleinemeier", "Vertical Engineers Engine (VEE)", "2011", "Roly Williams", "http://rolywilliams.com/kleinemeier.html", 4, " Inspired by the original Meccano engine", "2011-11-19 15:20:00", 0)

        IE(oC, 629, "David Auld", "Steam Launch", "1980s", "Scalex", "", 5, "Engine is a David Auld,steam launch made in the mid to late 1980's only limited numbers where made but exact mumber is unkown", "2011-11-24 08:06:00", 0)

        IE(oC, 630, "Renown", "Steam Roller", "???", "Scalex", "", 2, "", "2011-11-24 08:10:00", 0)

        IE(oC, 631, "Steam Craft", "Vertical Engine", "2011", "Scalex", "", 3, "Very nice smooth runner", "2011-11-24 08:15:00", 0)

        IE(oC, 632, "Steam Craft", "Horizontal Engine", "2008", "Scalex", "", 1, "Good runner", "2011-11-24 08:20:00", 0)

        IE(oC, 633, "Fleischmann", "Punch-Press #224", "1954", "Marcel", "", 3, " I am pretty sure of the information - let's make it 90% sure  :-)", "2011-11-24 08:24:00", 0)

        IE(oC, 634, "Mamod", "TE1", "1963", "Chris", "", 1, "The Very First Early 1963 Nut&Bolt Groved Wheel Smooth Canopy Mamod TE1.", "2011-11-28 08:04:00", -10)

        IE(oC, 635, "Plank", "Stationary", "c1910", "Silver Fox Steam", "", 5, "This is a small Plank stationary engine, just a little bigger (and possibly a little older) than Benchmark's Plank 425. They make an interesting comparison. Note the spiral spokes of the flywheel and the side opening for the burner. My guess is that this model would date from around 1910. It has undergone a 'heavy repair', receiving a new boiler barrel, safety valve, whistle handle, burner and chimney. The chimney cap was spun from brass especially for this engine. The final picture shows the state prior to restoration.", "2011-12-03 10:20:00", 0)

        IE(oC, 636, "Plank", "Vertical", "c1910", "Silver Fox Steam", "", 2, "Another 'heavy repair' job on this one. I kept the colours as close as possible to (what was left of) the original. An oscillating cylinder engine mounted on a frame fixed to the firebox. It has a whistle and safety valve/filler. It is fired by a single wick spirit burner. Date - c1910 (a convenient approximation for pre WW1).", "2011-12-03 10:24:00", 0)

        IE(oC, 637, "Fleischmann", "125-2", "c1960", "Silver Fox Steam", "", 4, "A complete example of this model, c1960. The engine has a 'blued' (chemically treated brass) boiler, 'Esbit' solid fuel burner, 'bell' whistle, in-line oiler and a non-working governor driven from the flywheel.", "2011-12-03 10:29:00", 0)

        IE(oC, 638, "Marklin", "4097-6", "c1935", "Silver Fox Steam", "", 1, "This is one of Marklin's biggest regular production engines, from around 1935. I suspect that the flywheel is not the original, otherwise all features are authentic. A very handsome and quite powerful engine.", "2011-12-03 10:32:00", 0)

        IE(oC, 639, "AB Alga", "John Ericsson", "1975", "Robertosala", "", 3, "This steam engine is complete with accessories. The accessories are very, very rare. When they show up, are usually sold very expensive.  The original accessories consist of a grinder wheel with a polisher wheel combination, a transmission and a lathe. Quality is of the accessories is outstanding; just like the engine itself. John Ericsson steam engines were used in schools to teach youngsters. They have special safety features not found in any other steam engine.", "2011-12-08 07:59:00", 0)

        IE(oC, 640, "Wilesco", "D8", "est 1950", "Wim Gregoor", "", 6, "Wilesco D 8 restored: cleaned, polished, replaced: whistle top scale, fillplug, burner, smokestack, or. weight.", "2011-12-10 09:50:00", 0)

        IE(oC, 641, "Steam Craft", "Mini Horizontal", "2011", "Scalex", "", 4, "SteamCraft miniature horizontal engine boiler is 70mm long 25mm wide made in 2011.", "2011-12-12 08:27:00", 0)

        IE(oC, 642, "Falk", "Printing Press", "???", "Wim Gregoor", "", 4, "The Falk press comes with 3 clichés: rubber barrel-stamps, ink-tampered by the above-laying felt ink-tamper. The press-paper from a paper-roll behind the press (in the black holder) was led to the pressing-table. Now moved by a steam-engine via the spring on the wheel 'Birds', 'Transportmeans' or 'Oriental Mammals' were pressed. The press came in this original box (lid replacement), with 'Drückmaschine', 'ekno 7', '3,50' and (modelnr.?) '242/3', written in pencil, black and blue.  About 'Joseph Falk' as the original mark of my press, I am not sure: contact with Lankes Auctions resulted in their mentioned origine, Falk. I have seen 3 more species on internet, no marks mentioned. I am open for suggestions about its origin and date.", "2011-12-19 08:15:00", 0)

        IE(oC, 643, "Stevens Model Dockyard", "Horizontal Engine #232", "c1910", "Tonupbear", "", 3, "Was covered in black paint, when cleaned off it revealed what I think are the original colours, nothing else has been done, the castings seem quite rough but it is totally original and runs very well.", "2012-01-03 12:20:00", 0)

        IE(oC, 644, "Maxwell Hemmens", "Marine Plant", "March 1994", "Ozsteamdemon", "", 4, "<p>Engine Spec`s:</p><p>Bore  -                                                       2 x 9.5 mm dia</p><p>Stroke  -                                                    15.8 mm</p><p>Operating Pressure -                                30 - 80 PSI</p><p>Recommended maximum propeller size - 4 Blade , 76 mm dia</p>", "2012-01-03 12:29:00", 0)

        IE(oC, 645, "Bowman", "Demon", "1927", "Colin Hewitt", "", 3, "Purchased at an estate sale for $150 Canadian (95GBP) in January 2012.", "2012-02-25 10:46:00", 0)

        IE(oC, 646, "Peake Engines", "Nano", "2012", "Swift Fox", "http://swiftfoxsteamco.webs.com/", 4, "This is the smallest engine to come out of Ben’s workshop so far, I’ve added a photo of it next to his second smallest engine the ‘micro’ and also one next to an Australian Dollar coin to give you a sense of scale.", "2012-02-25 10:50:00", 0)

        IE(oC, 647, "Peake Engines", "Nano", "2012", "Roly Williams", "http://rolywilliams.com/ben_peak_nano.html", 2, "This remarkable engine is all of 1 inch tall!", "2012-02-25 10:55:00", 0)

        IE(oC, 648, "Steamcraft", "Mallard", "1976", "Benchmark", "http://dampmaskiner.webs.com", 4, "This company should not be confused with 'Steam Craft Australia' . Steamcraft UK existed between 1976 and 1982 and was owned by David Taylor and quite a few different live steam models were made within this period It is claimed that only 180 examples of this particular live steam locomotive were made. The locomotive is OO/HO gauge and gas fired.", "2012-03-22 08:03:00", 0, "http://www.youtube.com/watch?v=TdJTCqTQw0c")

        IE(oC, 649, "Reeves", "Vulcan Beam Engine", "??", "Benchmark", "http://dampmaskiner.webs.com", 2, "Sold as unmachined castings.", "2012-02-25 11:10:00", 0, "http://www.youtube.com/watch?v=CC9gJYJOeXI")

        IE(oC, 650, "Philcraft", "Jenny Wren Limited Edition", "2012", "Benchmark", "http://dampmaskiner.webs.com", 2, "One of the smallest steam engines commercially available, no larger than a box of matches. this is a special or custom edition which differs from the regular version by having custom wooden cladding, exhaust directed to the flue, wooden base and blued firebox.", "2012-02-25 11:15:00", 0, "http://www.youtube.com/watch?v=5DRgbLYjKcw")

        IE(oC, 651, "PM Research", "Model Drill Press", "2011", "Benchmark", "http://dampmaskiner.webs.com", 2, "Sold as unmachined castings. This lovely example was made by 'Dean' in the USA.  ", "2012-02-25 11:20:00", 0, "http://www.youtube.com/watch?v=mnzrHxllULg")

        IE(oC, 652, "PM Research", "8V Marine Engine", "2011", "Benchmark", "http://dampmaskiner.webs.com", 2, "Sold as a set to be assembled with simple hand tools.", "2012-02-25 11:25:00", 0, "http://www.youtube.com/watch?v=XhR_TUfgOAY")

        IE(oC, 653, "Other", "Regner -- Victor II", "2010", "Benchmark", "http://dampmaskiner.webs.com", 3, "Sold by Krick but manufactured by Regner of Germany. ", "2012-02-26 20:27:00", 0, "http://www.youtube.com/watch?v=4G1YT4a809c")

        IE(oC, 654, "Other", "SVS Steam -- Double Oscillator Marine", "??", "Benchmark", "http://dampmaskiner.webs.com", 1, "Originally made in the UK but long since out of production and the company no longer exists. ", "2012-02-26 20:30:00", 0, "http://www.youtube.com/watch?v=H-bWUSn0yMM")

        'IE(oC, 655, "Other", "J.C Proteus -- Proteus Turbine II", "??", "Benchmark", "http://dampmaskiner.webs.com", 2, "First series of steam turbines made by the French company J.C Proteus, this model has been discontinued and the ones for sale now are called 'Proteus II'. ", "2012-02-26 20:34:00", 0, "http://www.youtube.com/watch?v=52BenSIXmyE")

        IE(oC, 656, "Jensen", "Jensen #20 Big Power Plant", "??", "Benchmark", "http://dampmaskiner.webs.com", 2, "First series Jensen 20G model with cast iron base generator  which the modern models produced now are lacking.", "2012-02-26 20:36:00", 0, "http://www.youtube.com/watch?v=CC_IRcoUhOs")

        IE(oC, 657, "LS LOC", "Mini Rocket Loco (OO-HH scale)", "1977", "Benchmark", "http://dampmaskiner.webs.com", 2, "This Swiss company specialized in gold plated miniature live steam engines. Produced in 1977 the series are not made any more and a coveted collectors item.   -Mini-Rocket spur&#65279; HO 9 cm   - Mini-Sans Pareil spur HO 11 cm  - Mini-Dampftractor 8,5 cm   - Mini-Dampfmachine 6,5 x 6,5 cm", "2012-02-26 20:40:00", 0, "http://www.youtube.com/watch?v=7fqj5LwguPQ")

        IE(oC, 658, "Other", "Maier -- Classic 2 Stroke", "2009", "Benchmark", "http://dampmaskiner.webs.com", 3, "This German company specializes in different types of gas engines.", "2012-02-26 20:47:00", 0, "http://www.youtube.com/watch?v=cANFpuls8UU")

        IE(oC, 659, "Other", "CMS -- Single Cylinder", "2011", "Benchmark", "http://dampmaskiner.webs.com", 2, "UK based Chiltern Model Steam provides a range of model steam engine kits, fully  machined, that can easily be assembled into fine examples . 3 models are made by this company: - single cylinder engine - double cylinder engine - vertical Marine engine ", "2012-02-26 20:52:00", 0, "http://www.youtube.com/watch?v=Qmo17CHQ5zs")

        IE(oC, 660, "Hielscher", "Metafot Boiler", "???", "Benchmark", "http://dampmaskiner.webs.com", 2, "This little beauty was made by Heilsher's former foundry ' Metafot' in Wuppertal Germany. They have long been discontinued.", "2012-02-26 20:56:00", 0, "")

        IE(oC, 661, "Roundhouse Engineering", "Millie", "2007", "Benchmark", "http://dampmaskiner.webs.com", 2, "One of Roundhouse engineering's Basic models. A very powerful gas fired locomotive in  O gauge (32mm)", "2012-03-22 08:19:00", 0, "http://www.youtube.com/watch?v=TdJTCqTQw0c")

        IE(oC, 662, "Other", "Engineers Emporium -- Little Wonder", "??", "Benchmark", "http://dampmaskiner.webs.com", 2, "This is a model of a common farm yard engine. This one is glow fired and water cooled.", "2012-02-26 21:04:00", 0, "http://www.youtube.com/watch?v=a2lAOw3tUAE")

        IE(oC, 663, "Mamod", "TE1V Ltd Edition", "2012", "Casey Jones", "http://www.charnwoodforestrailway.webs.com/", 3, "Engine is number 88 of 200.", "2012-03-10 18:46:00", 0, "")

        IE(oC, 664, "Mamod", "SW1", "1972", "Casey Jones", "http://www.charnwoodforestrailway.webs.com/", 2, "Early spirit(Meths) fired SW1.", "2012-03-10 18:48:00", 0, "")

        IE(oC, 665, "Schoenner", "107-13", "1900-1906", "Earlytimes (Robert L)", "", 3, "This engine was originally purchased in Canada by a the Grandfather of the woman I bought it from. He worked for the Rail Road in Vancouver. ", "2012-03-10 18:55:00", 0, "")

        IE(oC, 667, "Marklin", "4112-8", "1920s", "Earlytimes (Robert L)", "", 2, "", "2012-03-11 04:40:00", 0, "")

        IE(oC, 668, "Hornby", "Flying Scotsman (L.E.)", "2005", "Benchmark", "http://dampmaskiner.webs.com", 3, "Contrary to the normal live steam single tender edition, only 1000 examples of  the double tender edition were ever made worldwide. This is one of them. Scale : OO/HO", "2012-03-22 08:07:00", 0)

        IE(oC, 669, "Mamod", "William", "2005-2006", "Benchmark", "http://dampmaskiner.webs.com", 3, "Mamod have made locomotives with oscillating cylinders in the past and this was their slide valve engine version. It is a surprisingly impressive runner though may not be too attractive for realistic garden rail modellers due to its 'toy look' . However, it makes a very affordable entry into the gas fired/slide-valve locomotive class and a good base for  cosmetic modifications as can be seen in the last photo.", "2012-03-22 08:12:00", 0, "http://www.youtube.com/watch?v=MFodO2kQXdw")

        IE(oC, 670, "Roundhouse Engineering", "Lady Anne", "1997", "Benchmark", "http://dampmaskiner.webs.com", 3, "One of Roundhouse engineering's classic models. This model is RC controlled .A very powerful gas fired locomotive ,with adjustable gauges (32mm and 45mm)", "2012-03-22 08:14:00", 0)

        IE(oC, 671, "Karsten Gintschel", "Tornado Lok-O-Mobil", "2011", "Dave's Engine Room", "", 2, "The new 'Tornado' Lok-O-Mobil from Karsten Gintschel features the addition of two extra railway cars, as well as a speed control as part of the reversing switch. The decorator box includes space for all the HO scale track sections and all pieces. The track is powered from the matched 'Tornado' turbine generator.", "2012-04-02 07:50:00", 0)

        IE(oC, 672, "Karsten Gintschel", "Tornado Electric Hammer", "2011", "Dave's Engine Room", "", 1, "This nice little hammer is included in the 'Tornado line from Karsten Gintschel and is powered from the turbine generator. The figurine is 1:32 scale.", "2012-04-02 07:52:00", 0)

        IE(oC, 673, "Karsten Gintschel", "Anno 1900 Herons Turbine", "2009-10", "Dave's Engine Room", "", 1, "Karsten Gintschel's 'Anno 1900' line features this balanced variation of the original Heron's turbine. ", "2012-04-02 07:54:00", 0)

        IE(oC, 674, "Karsten Gintschel", "Tornado Line Complete", "2011", "Dave's Engine Room", "", 2, "The latest line of models from Karsten Gintschel. Karsten has added a new woodshop to his expanded production facility, so all new models come with his trade-mark attractive wood boxes. Karsten was good enough to send me serial No. 001 after he featured this machine line on his website http://modellbau-gintschel.de and these models are still available (March 2012)", "2012-04-02 07:56:00", 0)

        IE(oC, 675, "Karsten Gintschel", "Anno Line Complete", "2009-10", "Dave's Engine Room", "", 1, "The 'Anno 1900' line from Karsten Gintschel features a matched Lok-O-Mobil on HO scale track, and a Heron's Ball stationary steam machine. The turbine generator can power at least four lights as well as the Lok-O-Mobil. A forward-reverse switch is included.", "2012-04-02 07:59:00", 0)

        IE(oC, 676, "Karsten Gintschel", "Anno Lok-O-Mobil", "2009-10", "Dave's Engine Room", "", 1, "The Anno 1900 Lok-O-Mobil features a approx. 1:32 scale figure and engine on an HO scale track. It is powered by the matching turbine generator.", "2012-04-02 08:00:00", 0)

        IE(oC, 677, "Karsten Gintschel", "Fury II Turbine Generator", "2006", "Dave's Engine Room", "", 3, "This is a unique design of Karsten's, made in 2006. It has a trough for catching condensate (not shown) and connections in the front for additional lights as well as lighting up the machine with the mounted LED lights. It might be hard to see the XXX serial number in the center of the badge, this was Karsten's own model and he was kind enough to send it to me (after payment)!", "2012-04-02 08:02:00", 0)

        IE(oC, 678, "Karsten Gintschel", "Anno 1900 Turbine Generator", "2009-10", "Dave's Engine Room", "", 1, "The turbine generator is equipped to power at least four LED lights and the Lok-O-Mobil.", "2012-04-02 08:04:00", 0)

        IE(oC, 679, "Karsten Gintschel", "DT-40 Turbine Generator", "2010", "Dave's Engine Room", "", 2, " Karsten designed the DT-40 as an 'introductory' machine for beginning hobbyists. While it's a simple, no-frills machine, a welcome change was the removable condensate cup under the turbine. And just because it's short on hand rails and detail, it's not short on power!", "2012-04-02 08:05:00", 0)

        IE(oC, 680, "Bing", "130-275", "c1909", "Earlytimes (Robert L)", "", 2, "  Engine has 'Rollenflachschieber' Valve gear, and is in Original condition.", "2012-04-02 08:17:00", 0, "")

        IE(oC, 681, "Karsten Gintschel", "Tornado Turbine Generator", "2011", "Dave's Engine Room", "", 3, "Karsten Gintschel's new 'Tornado' turbine generator come fully contained in it's own decorator wood box, as will all future models from the maker. All pieces are included, the three movable lights (two standing, one floodlight), condensate cup which proves much better than an attached cup, space for filling syringe and directions, even the 1:32 scale figurine comes along for the ride! A new feature on the 'Tornado' turbine is a flame guard housing, eliminating the effects of drafts on an exposed burner.", "2012-04-02 18:25:00", 0)

        IE(oC, 682, "Tucher and Walther", "T-208 schiff Elisabeth Joanna", "1982", "Dave's Engine Room", "", 3, "When Tucher & Walther were repairing collection pieces and making decorations they decided to introduce their own original steam-driven items. In 1982, their first two pieces were a train and boat called the 'Elisabeth Joanna', which is named after Mr. Tucher’s daughter (NOT Frau Elisabeth Walther, the firm partner). As is common for future steam driven toys, the ship is powered by a Wilesco D15 vertical engine and a boiler from the D6-D8 stationary engine. Many different steam powered boats followed", "2012-04-02 20:06:00", 0)

        IE(oC, 683, "Tucher and Walther", "T-461 Flugapparat (Flying Machine)", "May 4th 2006", "Dave's Engine Room", "", 3, "This is Herr Tucher's first 'flying boat'. Along with the Wilesco D-15 vertical engine and D-6 boiler, this and future toys also feature a 3V electric engine which runs at a much slower rate than under full steam. There's a lot going on when this is running! The propellers spin, the wings flap, and the whole machine shakes, rattles and (just about) rolls! A very creative and interesting piece. One photo shows the dated and signed Certificate of Authenticity and edition number tag. These were a limited edition of 100.", "2012-04-02 20:09:00", 0)

        IE(oC, 684, "Tucher and Walther", "T-714 Mondrakete (Moon Rocket)", "June 27th 2007", "Dave's Engine Room", "", 4, "A fun and fanciful toy! Berhnard Tucher paid a beautiful tribute to the 1902 silent film 'La Voyage dans la Lune' Voyage to the Moon. His figurines are pressed from high quality steel, joined and painted by hand to achieve their great detail. Horizontal as well as vertical propellers all spin simultaneously to create quite a breeze. A 3V electric motor is included as well as the signature Wilesco D-15 vertical motor and D-6 boiler. The sign on the base, printed in German, outlines the homage to the great old silent movie. An anchor is added to keep the machine in a holding pattern!", "2012-04-02 20:11:00", 0)

        IE(oC, 685, "Tucher and Walther", "T-999 Space Man", "Jan 28th 2008", "Dave's Engine Room", "", 3, "There are no limits to Tucher & Walther's imagination! He's such a cutie! Space Man rolls along under his own power by a Wilesco D-15 vertical engine (hidden in his chest) and a D-6 boiler for a knapsack. The exhaust steam is vented out his mouth, and there's a battery pack in the rear of his head to make his red eyes flash. His antenna also spins from a spring belt from the engine. Comes with a signed certificate and an edition number tag, limited to 100 pieces.", "2012-04-02 20:14:00", 0)

        IE(oC, 686, "Tucher and Walther", "T-751 Luftschiff Victoria", "Dec 16th 2009", "Dave's Engine Room", "", 3, "'His Last Bow; (with due respect to Sir A.C. Doyle). This is the last major steam toy from Berhnard Tucher. The company ceased operations on Dec. 31, 2009, my machine certificate was signed  on the 16th. The figurines are much busier on this flying boat than the T-461 made earlier. There's a drummer to keep up the pace, and a pair of rowers who paddle like crazy! We have, as always our man at the wheel and the stoker below decks to keep the Wilesco D-6 boiler firing the D-15 vertical engine. An electric engine gives the oarsmen a break, and they paddle at a much more leisurely pace. Although my edition number card say 'out of 100' pieces, less than 35 were made. The exact number is kept by Tucher & Walther to prevent forgery. A fitting tribute to a most creative toy shop. Vielen Dank.", "2012-04-02 20:20:00", 0)

        IE(oC, 687, "Kontax", "KS90T", "2012", "Camst648", "", 2, "A Kontax twin cylinder low temperature differential Stirling engine KS90T at full speed", "2012-04-16 08:14:00", 0)

        IE(oC, 688, "Bohm", "HB24", "2011", "Camst648", "", 2, "Vacuum Motor, also known as flame eater or flame gulper. patented by Hendry Wood in 1758.", "2012-04-16 08:16:00", 0)

        IE(oC, 689, "Bohm", "HB34", "2012", "Camst648", "", 2, "The engine make a great noise, quite low res considering it's size.", "2012-04-16 08:19:00", 0)

        IE(oC, 690, "Wiggers", "Stirling HHV-08-250", "2012", "Camst648", "", 2, " Most of the information about Wiggers Stirling can be found on their website : http://www.stirling-model-engineering.com/index.php?c=content/en/wirueberuns/wirueberuns.php . It is not mutch, but it is what they themselfe wish to share with the rest of us, so digging any deeper would be to intude. I can however ad as my personal view that Wiggers and Werner Wiggers himselfe probably is the best produser/prodused handcrafted Stirling engines on the maket today. ", "2012-04-16 18:21:00", 0, "http://www.youtube.com/watch?v=wVT5_z1Zmwc")

        IE(oC, 691, "Steamcraft", "4-6-0 GWR King Class Express", "1976", "Benchmark", "http://dampmaskiner.webs.com", 3, "An exquisite Steamcraft model,the 4-6-0 GWR KING CLASS EXPRESS was built by David Taylor himself . He ran it intermittently and between runs it stood in a glass box in his office.", "2012-05-09 07:47:00", 0, "http://www.youtube.com/watch?v=GLWjtDhjJI0")

        IE(oC, 692, "Jean Comby", "Unknown Model", "???", "Jeff46u", "", 2, "No union sticker or markings of any kind. Some one put Jensen handles on it.", "2012-05-09 07:51:00", 0, "http://www.youtube.com/user/Jeff46u/videos")

        IE(oC, 693, "Jensen", "Jensen #10", "1952 to 1955", "Jeff46u", "", 3, "", "2012-05-09 08:01:00", 0, "http://www.youtube.com/user/Jeff46u/videos")

        IE(oC, 694, "Jensen", "Jensen #5", "Early 1960s", "Jeff46u", "", 2, "This is next to the last style Jensen #5 made.", "2012-05-09 08:03:00", 0, "http://www.youtube.com/user/Jeff46u/videos")

        IE(oC, 695, "Jensen", "Jensen #5", "Circa 1964", "Jeff46u", "", 1, "This is the very last style of #5 made on a metal base with holes drilled for a #75 or #25.", "2012-05-09 08:05:00", 0, "http://www.youtube.com/user/Jeff46u/videos")

        IE(oC, 696, "Jensen", "Jensen #100 Blue Base", "1948-50", "Jeff46u", "", 3, "On the first couple year Jensen #100 workshops the base was painted blue. The Jensen workshop was discontinued in 1985. This particular #100 has never been run in orgianl box and packing. You will notice the belt that goes from the workshop to the engine is still in the original envelope. ", "2012-05-09 08:08:00", 0, "http://www.youtube.com/user/Jeff46u/videos")

        IE(oC, 697, "Empire", "B-38 Hot Air Engine", "1924-41", "Stitch", "http://toysteamparts.com/patches.html", 1, "The engine was generally used to power revolving store displays. It was also marketed as 'Electric Submarine Engine'.", "2012-05-14 20:57:00", 0, "")

        IE(oC, 698, "Wilesco", "D3", "2011", "R Smith", "", 1, "An on going project of mine. So far the boiler and steam pipe have been cladded. Future plans are to replace the base plate and add a condenser", "2012-05-14 21:00:00", 0, "")

        IE(oC, 699, "Peake Engines", "V2", "2012", "Swift Fox", "http://swiftfoxsteamco.webs.com/", 4, "This is the first multi cylinder engine produced for general sale by Peake Engines, it was designed and built by Ben Peake and Bruen Smith. The engine is a v-twin single acting oscillator and is built in a similar style to the Peake no3.", "2012-05-15 19:03:00", 0)

        IE(oC, 700, "Bowman", "Vertical Punch Press", "c1931", "W. Wrench", "", 1, "This punch appears to be of good quality and has a solid metal base. The body is made of cast iron, and the wheels are also cast with a griped inner edge to prevent wire drive band slippage. The press mechanics are well engineered and this punch actually works on paper and light cardboard, punching out neat holes.", "2013-01-26 18:55:00", 0)

        IE(oC, 701, "Bowman", "Vertical Band Saw", "c1931", "W. Wrench", "", 1, "This band saw has a solid metal base, and cast iron body. The wheels are also cast with a none slip inner edge. The lower left hand wheel being driven by the engine transfer dirve band and this in turn drives the lower right hand wheel. That wheel would be connected to the upper drive wheel by a fleixable saw blade currently demonstrated with a rubber band as a blade. The blade passes through a movable guide foot. The upper wheel is ajustable to take up the slack in the cutting saw blade. I have no idea if one was actually manuafctured for the job, but suspect that it was, because this is a working model, and all parts move well.", "2013-01-26 18:55:00", 0)

        IE(oC, 702, "Bowman", "832 Bath Tub Griding Stone", "c1931", "W. Wrench", "", 1, "This model appears to be good quality, and the base is metal. The body is bakerlite, and the grinding stone is an actual real grinding stone, and the bath tub is watertight. The stone appears unused, and the model is a working model. ", "2013-01-26 18:55:00", 0)

        IE(oC, 703, "Unknown", "Table Wood Planer", "???", "W. Wrench", "", 1, "This wood plane has a tin body, and a metal top which is hinged allowing it to be lifted to empty out wood shavings. It actually had shavings in it at the time of purchase, and had obvioulsy been used. The spindle drives a single rotary blade with two sharp cutting edges. There is a upper brass thread with nothing attached to it. I suspect that some sort of wood guide would have been attached here, but that part is missing. If anyone has one of these, please send me a photograph so I can get the missing part made.", "2012-05-22 07:26:00", 0)

        IE(oC, 704, "SEL", "Drive Line Shaft", "???", "W. Wrench", "", 1, " 4 Pulleys & one drive wheel. All original paintwork.", "2012-05-22 07:26:00", 0)

        IE(oC, 705, "SEL", "Power Press", "???", "W. Wrench", "", 1, "Model number 3050 together with its original box & packing.", "2012-05-22 07:27:00", 0)

        IE(oC, 706, "SEL", "Grinder", "???", "W. Wrench", "", 1, "Model number 3020 together with its original box & packing.", "2012-05-22 07:29:00", 0)

        IE(oC, 707, "SEL", "Fan", "???", "W. Wrench", "", 1, "Model number 3000 together with its original box & packing.", "2012-05-22 07:30:00", 0)

        IE(oC, 708, "SEL", "Lathe", "???", "W. Wrench", "", 1, "Model number 3080. One headstock missing. If anyone has a photo of the complete model, please send me a copy so that I can make the missing item.", "2012-05-22 07:32:00", 0)

        IE(oC, 709, "Meccano", "MEC1", "c1960", "W. Wrench", "", 1, "This engine is still all original. It has a standard pressure release valve, forward and reverse lever, and the two drive shaft gears to the main balance wheel.  It is displayed with its original box, which has a lovely wrap round picture of a Black Country engineers work shop, and pictorial items that can be built with Meccano to suit this engine, ie, Printing Machine, Windmill & Stamping Machine.", "2012-05-31 07:42:00", 0)

        IE(oC, 710, "Mamod", "ME1", "c1960-70", "W. Wrench", "", 1, "This enigine is original and complete, but requires attention in my workshop. It comes with its box, instructions, and advice tickets still attched. I first purchased one identical to this in 1966 and put in a purpose built wooden ship (tanker type) specially manufactured by a model company in conjunction with Mamod for this engine. It has a meths burner.", "2012-05-31 07:44:00", 0)

        IE(oC, 711, "Mamod", "SE1 and Workshop", "c1960s", "W. Wrench", "", 1, "This engine is complete,with a standard meths burner, pressure release valve, side water filling plug, motion speed control lever. This is not a forward & reverse lever. These engines drive in one direction only. It is set on a display board together with Mamod Drive shaft, Grinder wheels, Verical press, Drop hammer, and twin Buffer Polishing wheels. All of these tools are circa 1960s to 1970s and are complete with drive bands. The complete set is a fully working model. Note that Mamod often changed the boiler facing direction. In this case the meths burner is on the balance wheel side of the engine. Compare this with other models I have submitted.", "2012-05-31 07:47:00", 0)

        IE(oC, 712, "Mamod", "SE2A and Workshop", "c1970s-80s", "W. Wrench", "", 1, "This engine is complete and is a fully working model. It has the more modern type whistle, a pressure relief valve, and side boiler filler. Note there are 3 brass boiler pipes, one input to the piston head and two relief to the chimney stack, which are required for this foward / reverse engine. On this model the meths burner is set though a matching hole in the base plate, and is facing outwards away from the balance wheel. The engine is on a display board running a full set of Mamod tools circa 1960s 1970s and they are :- Drop Hammer, Vertical press, double Grinding Wheels, and double Polishing wheels, all driven via a Mamod line shaft.", "2012-05-31 07:49:00", 0)

        IE(oC, 713, "Mamod", "SE2", "c1960-70", "W. Wrench", "", 1, "This engine has been totally refurbished by myself, with all of its oringinal parts, because it was in a poor condition and unsafe to use. The engine has a standard pressure release valve, side boiler filler, the older brass type whistle, and a single feed pipe to the piston head, with one relief pipe to the chimney. It has a meths burner, and this sits at base plate height, and is not sunken. Note the burner entarnce is also on the balance wheel side.", "2012-05-31 07:51:00", 900)

        IE(oC, 714, "Mamod", "SP5 and Workstation", "c1970s", "W. Wrench", "", 1, "This enigine is complete and is a twin piston fully working model. It has a standard pressure relief valve, and a brass type whistle, with an end boiler water level glass sight. The burner is a solid fuel tablet type. There is one boiler outlet pipe to the piston heads, and two returns to the detachable chimney. It is fitted with a dual level for forward and reverse.  It has the silver tin oil splash plate. The engine is attached to the modern Mamod fully working tool station, which is colured in blue, and not the old lime green, used on the more older working tools.", "2012-05-31 07:53:00", 0)

        IE(oC, 715, "Wilesco", "D14 and Workshop", "c1970s", "W. Wrench", "", 1, "This Wilesco engine is a fully working model, with an end water sight glass, pressure relief valve, whistle, piston speed valve, tablet burner, and steam drip tray. It has one output steam pipe to the overhead piston head, and one relief pipe to the detachable chimney. It is displayed on a board together with a Wilesco modern tool station comprising of a table bench saw, twin wheel grinders, and a vertical pillar drill. These tools are all working tools. The 4 way line shaft being pre fitted on this set. Note that this is an early type D14. The way to find out is by measuring the diameter of the thread to the pressure relief valve. I puchased a modern compessed air adaptor only to find out it was too small, and that was because Wilesco made the older version D14 with bigger drilled and tapped hole into the boiler.", "2012-05-31 07:55:00", 0)

        IE(oC, 716, "Bowman", "E135", "1920s - early 30s", "David Walmsley", "", 1, "This engine is in original 'play worn' condition", "2012-05-31 07:57:00", 0)

        IE(oC, 717, "Bowmans of Luton", "PW202", "1946-50", "David Walmsley", "", 2, "  This engine has not been restored and is in 'play worn' condition. Has it's original box which is in excellent condition.", "2012-05-31 23:26:00", 0)

        IE(oC, 718, "Peake Engines", "No 4 Powerhouse", "2012", "Unknown", "", 5, "This is the first beam engine ever made by Peake engines and the second engine to feature the ‘Sun & Planet’ gear, the engine is named after the 1785 Boulton & Watt beam engine in the Powerhouse Museum in Sydney which is the oldest rotative beam engine in existence. This is one of the rarest engines to come out of the Peake workshop to date with just 11 examples being made.", "2012-06-26 07:53:00", 0)

        IE(oC, 719, "Wilson Bros", "Vertical", "c1940s", "Roly Williams", "http://rolywilliams.com/wilson_vertical.html", 1, "", "2012-07-06 07:20:00", 0)

        IE(oC, 720, "Rattandeep", "Speedboat", "c2000-10", "Roly Williams", "http://rolywilliams.com/rattandeep_speed_boat.html", 1, "Pop-pop boat", "2012-08-03 07:52:00", 0)

        IE(oC, 721, "Rattandeep", "Tug boat", "c2000-10", "Roly Williams", "http://rolywilliams.com/rattandeep_tug_boat.html", 1, "Pop-pop boat", "2012-08-03 07:58:00", 0)

        IE(oC, 722, "Rattandeep", "Titanic", "c2000-10", "Roly Williams", "http://rolywilliams.com/rattandeep_titanic.html", 1, "Titanic pop-pop boat", "2012-08-03 07:59:00", 0)

        IE(oC, 723, "Mamod", "Centurion Fred Dibnah", "2011", "GaryD", "", 3, "This is a special edition Fred Dibnah version of the centurion piston valve engine. It was supplied by Steam4fun.", "2012-08-03 08:04:00", 0)

        IE(oC, 724, "Wilesco", "D2", "2012", "GaryD", "", 3, "This is Wilesco's latest and smallest engine.", "2012-08-03 08:06:00", 0)

        IE(oC, 725, "Wilesco", "D455", "2012", "GaryD", "", 3, "A classic of the Wilesco range. A good runner even at low revs.", "2012-08-03 08:09:00", 0)

        IE(oC, 726, "Bowman", "M167", "1920-1935", "David Walmsley", "", 1, "The engine has a chimney, which was optional extra at the time. Also has the original funnel and it's wooden box.  The engine is completely original, but possibly the base and firebox have been repainted some time ago.", "2012-08-03 08:12:00", 0)

        IE(oC, 727, "Wilesco", "D16 and Workshop", "1970s", "Dietmar Kolb", "http://www.kleinstmotoren.eu", 1, "", "2012-08-12 07:30:00", 0, "http://youtu.be/5WsWrmhu3eo")

        IE(oC, 728, "ADE", "Vertical", "1948", "Dietmar Kolb", "http://www.kleinstmotoren.eu", 1, "", "2012-08-12 07:32:00", 0, "http://www.youtube.com/watch?v=yXciyAW7304")

        IE(oC, 729, "ADE", "50-12", "1950", "Dietmar Kolb", "http://www.kleinstmotoren.eu", 2, "", "2012-08-12 07:35:00", 0, "http://www.youtube.com/watch?v=rQl0tq7joVw")

        IE(oC, 730, "Wilesco", "D14", "2000s", "Dietmar Kolb", "http://www.kleinstmotoren.eu", 2, "", "2012-08-12 07:36:00", 0, "http://www.youtube.com/watch?v=1RzwMbks2Uo")

        IE(oC, 731, "Wilesco", "D455", "2000s", "Dietmar Kolb", "http://www.kleinstmotoren.eu", 3, "", "2012-08-12 07:38:00", 0, "http://www.youtube.com/watch?v=HVa5iNJ48-c")

        IE(oC, 732, "Wilesco", "D52", "???", "Roly Williams", "http://rolywilliams.com/wilesco_d52.html", 4, "", "2012-08-15 21:03:00", 0)

        IE(oC, 733, "Marklin", "4158-7", "c1936", "Dave's Engine Room", "", 4, "The 'flagship of the fleet'. The 4158 is the model the 16501 replica was modeled after. Many different models were built during its history ending in 1940. The feedwater pump was someitme mpounted on the other sdie of the base, the most rare versions have the 'newest' 3394 dynamo attached, and featured up to a 9 cm dia. boiler (4158/94/11). Marklin did make larger engines than the 4158, but this models is the most popular and most common. This is one of the machines that demonstrate the epitome of the pre-war era.", "2012-08-20 11:50:00", 0)

        IE(oC, 734, "Marklin", "4149-9", "1919", "Dave's Engine Room", "", 4, "My favorite Marklin. This large flywheeled single cylinder is, in a way, the same in comparison of the 4158 like the Wilesco D28 and D32. With the 9cm dia. boiler and a valve to control the steam outlet, this machine just roars when placed under full steam. It is a stout but very well-balanced machine. It's rarity is a bit of  pity, it's a wonderful engine.", "2012-08-20 11:52:00", 0)

        IE(oC, 735, "Wilesco", "D28", "???", "Dave's Engine Room", "", 3, "The Fastest Wilesco! The D28 did not have a very long run and quite rare. Its boiler is larger than the D24's and the engine is raised on a small platform. The American version has a 1500W heating element, and when you build up pressure and open it fully, there is none faster. Considering the D32 has only 25% more (larger) boiler, yet 100% more engine (2), nine can compare to this great but rare Wilesco.", "2012-08-20 11:54:00", 0)

        IE(oC, 736, "Marklin", "4097-92-7", "1931-40", "Dave's Engine Room", "", 3, "The height of the platform gives this machine away as a pre-war build. Some 4097/7s were built post-war but the engine platform is much lower. This nice example comes with a 3392 dynamo and a 3447 lamp. I can't see any mounting holes on the base for the lamp, as some lamps were attached by screws. The furnace door is missing its latch, and it's evident that this engine was played with, but like most Marklins, it has held up admirably!", "2012-08-27 12:02:00", 0)

        IE(oC, 737, "Marklin", "4099-92-8", "1939-55", "Dave's Engine Room", "", 3, "The Schiffmann Sammlerkatalog lists the 4098/92/8 as being built post-war, but the engine base is the same as the 4097 pre-war. The boiler on this design is 8cm diameter and constructed with more ridging for strength than the earlier brass boilers. I added the 3392 dynamo later, but the mounting holes are pre-drilled for its installation. A solid toy strongly constructed for the discerning enthusiast.", "2012-08-27 12:05:00", 0)

        IE(oC, 738, "Marklin", "Boiler Comparison", "1931-55", "Dave's Engine Room", "", 4, "7cm/8cm/9cm boilers.  A comparison of Marklin's mid-sized machines by boiler diameter. Yes, midsized, as a few Marklin models have boilers up to 11cm diameter! Shown are a 4097/7, a 4098/8, and a 4149/9 side-by-side to show just a fraction of the complete Marklin line.", "2012-08-27 12:08:00", 0)

        IE(oC, 739, "Wilesco", "D3", "2000s", "M8Dave", "http://davestinplate-engines.webs.com/", 2, "", "2012-08-27 12:10:00", 0)

        IE(oC, 740, "ADE", "47-20", "1947-1960", "Peter's Toy Steam", "http://www.peters-toysteam.se", 3, "Engine is 13cm high.The advertisment is from Clas Ohlson in 1947.", "2012-08-27 12:17:00", 0)

        IE(oC, 741, "ADE", "49-11", "1949-1955", "Peter's Toy Steam", "http://www.peters-toysteam.se", 2, "This engine could be changed from a stationary to a locomobile by adding the wooden base.", "2012-08-27 12:20:00", 0)

        IE(oC, 742, "Swan", "M1", "1920-25", "Peter's Toy Steam", "http://www.peters-toysteam.se", 2, "The chimney was painted in cupper color as I got it, I believe it used to be black. The engine part had all color gone, so it's been repainted with the color scheme I've seen on another M1 model.", "2012-08-27 12:22:00", 0)

        IE(oC, 743, "Start", "No.4", "1986", "M8Dave", "http://davestinplate-engines.webs.com/", 4, "", "2012-08-27 12:26:00", 0)

        IE(oC, 744, "Unknown", "Unknown-6", "???", "Owen_F", "", 5, "Owen asks if we can help identify his engine... He says: I can't find any maker's name on it,the only lettering I can find are DRP on the steam chest. It appears to be quite an upmarket model with comprehensive fittings.   Height 19 1/4""  Boiler dia 41/4"" Cast iron base 61/2"" sq  Fittings-  Pressure gauge up to 50lbs sq ins marked GC Co N. Whistle. Gauge glass, Loco type.Governor, non operative.  Feed pump.Salter type safety valve.  A large cast iron door hinged to reveal a cast iron grate, method of firing unknown presumably meths.In the door there is apperture for checking the fire the lid is missing.All the handles were originally covered in wood, a few still exist. A six spoked fly wheel 43/4"" dia. ", "2012-09-01 17:30:00", 0)

        IE(oC, 745, "Marklin", "401", "1931-40", "Dave's Engine Room", "", 5, "The 401 is he ultimate in toys for boys (and men too). The unit acts as the power plant for many Marklin erector constructions illustrated in the booklet that accompanies the model. The 401 is even fun by itself. It's an upright! It's a overtype! It's a traction engine! This set is complete, with all the ""bits and bobs"" collars shafts, screws etc. Even the single size spanner has the G.M.&Cie shield logo stamped into it.", "2012-09-01 17:32:00", 0)

        IE(oC, 746, "Wilesco", "D8 EL", "1950s-60s", "Classixs", "http://steamup.dk/", 4, "Very clean sample with 220volt/180watt heater and old style Safety Valve and bakelite handle on whistle. The piston is a new style replacement, as the original old style has been salvaged for other purposes.", "2012-09-27 17:32:00", 0)

        IE(oC, 747, "Doll", "Vertical", "1930s", "F.Haeghens", "http://collectvalue.com/exhibition/steam%20toys%20and%20models/624", 1, "", "2012-10-27 15:45:00", 0)

        IE(oC, 748, "Bing", "Vertical", "1930s", "F.Haeghens", "http://collectvalue.com/exhibition/steam%20toys%20and%20models/624", 1, "", "2012-10-27 15:47:00", 0)

        IE(oC, 749, "Falk", "Vertical", "1930s", "F.Haeghens", "http://collectvalue.com/exhibition/steam%20toys%20and%20models/624", 1, "Smoke stack is not original", "2012-10-27 15:48:00", 0)

        IE(oC, 750, "Schoenner", "Vertical", "1930s", "F.Haeghens", "http://collectvalue.com/exhibition/steam%20toys%20and%20models/624", 1, "Smoke stack and fly where are not original", "2012-10-27 15:50:00", 0)

        IE(oC, 751, "Bing", "130-732 Locomobile", "1930-40s", "F.Haeghens", "http://collectvalue.com/exhibition/steam%20toys%20and%20models/624", 1, "", "2012-10-27 15:52:00", 0)

        IE(oC, 752, "Stuart Turner", "S50", "???", "F.Haeghens", "http://collectvalue.com/exhibition/steam%20toys%20and%20models/624", 1, "", "2012-10-27 15:55:00", 0)

        IE(oC, 753, "Unknown", "Unknown Mill-1", "???", "F.Haeghens", "http://collectvalue.com/exhibition/steam%20toys%20and%20models/624", 1, "", "2012-10-27 16:00:00", 0)

        IE(oC, 754, "Unknown", "Unknown Mill-2", "???", "F.Haeghens", "http://collectvalue.com/exhibition/steam%20toys%20and%20models/624", 1, "", "2012-10-27 16:02:00", 0)

        IE(oC, 755, "Bing", "Overtype", "1908", "F.Haeghens", "http://collectvalue.com/exhibition/steam%20toys%20and%20models/624", 2, "I restored this junk yard find based on a catalogue picture", "2012-10-27 16:06:00", 0)

        IE(oC, 756, "Falk", "Overtype", "???", "F.Haeghens", "http://collectvalue.com/exhibition/steam%20toys%20and%20models/624", 1, "", "2012-10-27 16:07:00", 0)

        IE(oC, 757, "Fleischmann", "Horizontal", "???", "F.Haeghens", "http://collectvalue.com/exhibition/steam%20toys%20and%20models/624", 1, "", "2012-10-27 16:08:00", 0)

        IE(oC, 758, "Marklin", "Horizontal", "???", "F.Haeghens", "http://collectvalue.com/exhibition/steam%20toys%20and%20models/624", 1, "This engine has been heavily restored", "2012-10-27 16:09:00", 0)

        IE(oC, 759, "Wilesco", "D24", "???", "F.Haeghens", "http://collectvalue.com/exhibition/steam%20toys%20and%20models/624", 1, "", "2012-10-27 16:10:00", 0)

        IE(oC, 761, "Plank", "Hot air engine", "???", "F.Haeghens", "http://collectvalue.com/exhibition/steam%20toys%20and%20models/624", 1, "The burner is from the same period but not original.", "2012-10-27 16:15:00", 0)

        IE(oC, 762, "Leybold", "Engine model", "???", "F.Haeghens", "http://collectvalue.com/exhibition/steam%20toys%20and%20models/624", 1, "Demonstration model made for schools etc.", "2012-10-27 16:19:00", 0)

        IE(oC, 763, "Unknown", "Unkonwn Mill-3", "???", "F.Haeghens", "http://collectvalue.com/exhibition/steam%20toys%20and%20models/624", 1, "Cutaway demonstation model", "2012-10-27 16:23:00", 0)

        IE(oC, 764, "Doll", "Horizontal", "???", "F.Haeghens", "http://collectvalue.com/exhibition/steam%20toys%20and%20models/624", 1, "Currently unrestored", "2012-10-27 16:23:00", 0)

        IE(oC, 765, "Doll", "Fountain", "???", "F.Haeghens", "http://collectvalue.com/exhibition/steam%20toys%20and%20models/624", 1, "", "2012-10-27 16:25:00", 0)

        IE(oC, 766, "Mamod", "Roadster", "???", "F.Haeghens", "http://collectvalue.com/exhibition/steam%20toys%20and%20models/624", 1, "", "2012-10-27 16:27:00", 0)

        IE(oC, 767, "Stevens Model Dockyard", "2004 Horizontal Engine", "1919 approx", "Tonupbear", "", 1, "This is the smallest engine of this model, 5/8"" bore , 5\8"" stroke, it is a chunky little engine and has broad'ish cylinder ridges, similar to the 232 model. Missing the exhaust pipe off the top.", "2012-10-27 16:33:00", 0)

        IE(oC, 768, "Bowman", "E167", "1920-35", "David Walmsley", "", 1, "A very nice example of the model. It's basically an E 158 without the countershaft.", "2012-10-28 07:54:00", 0)

        IE(oC, 769, "Bowman", "M130", "c1930", "David Walmsley", "", 1, "Very scarce Bowman. The original boiler was damaged and was replaced from an M130 that did not have a dynamo. The base may have been painted a long time ago, the rest is original and has been left as play-worn.", "2012-11-06 07:54:00", 0)

        IE(oC, 770, "Mamod", "Pre-war SE3", "c1937", "Roly Williams", "http://rolywilliams.com/mamod_se3_37.html", 2, "Pre-war (single cylinder) version of the SE3, would have originally branded Hobbies. The paintwork has been restored and the gears are Meccano replacements.", "2012-11-19 08:38:00", 0)

        IE(oC, 771, "Rattandeep", "Thunder Cruise", "2000s", "Roly Williams", "http://rolywilliams.com/thunder_cruise.html", 2, "Larger than usual pop-pop boat.", "2012-11-19 08:43:00", 0)

        IE(oC, 772, "CK", "V-Twin", "c1950?", "Roly Williams", "http://rolywilliams.com/ck_v_twin.html", 3, "A relatively rare model from CK in Japan", "2012-11-20 07:57:00", 0)

        IE(oC, 773, "Peake Engines", "No 6 Hypnocycle", "2012", "Unknown", "", 4, "This is the 6th engine in the ‘Peake’ family of models by Ben Peake of Australia and is based on the table engine design, it has a unique rotary valve arrangement driven via toothed gears connected the crankshaft of the flywheel, the engine is only single acting. Ben made a total of 51 engines and the first 5 of those came with a inline oiler as an added extra.", "2012-12-30 11:55:00", 0)

        IE(oC, 774, "Wilesco", "D14", "2012", "SmokingChimney", "", 1, "A very good running engine.", "2012-12-30 11:58:00", 0)

        IE(oC, 775, "Ind-X", "Electric Steam Engine", "?", "Roly Williams", "http://rolywilliams.com/ind-x_electric.html", 2, "", "2013-01-26 11:31:00", 0)

        IE(oC, 776, "Mr Power", "YB-001", "2013", "Kees van Kemenade", "", 1, "I bought this model this year, straight from the People's Republic. A simple oscillating, but well built, machine.", "2013-02-16 15:38:00", 0)

        IE(oC, 777, "John Ericsson", "Lathe", "1985", "Kees van Kemenade", "", 1, " A John Ericsson lathe, which is not shown on your website. I bought it new in 1985.", "2013-02-16 15:41:00", 0)

        IE(oC, 778, "Zongshan", "Unibody Engine", "2012", "Kees van Kemenade", "", 1, "A simple oscillating steam engine with a different design though. I bought it last year and received it just now. It was manufactures in Guangdong, China by the Zongshan Factory. It is described as 'Hot Live Steam engine Cylinder Unibody Design'. It is made  of aluminium and brass for the cylinder.", "2013-02-16 15:50:00", 0)

        IE(oC, 779, "Parken", "Horizontal", "1940s", "Verithingeoff", "http://www.verithingeoff.com", 3, "I bought the engine as a wreck, refurbished it and produced a new logo using a picture from Tony Muirs website [with his permission].  It is complete with the original burner", "2013-02-16 15:53:00", 0)

        IE(oC, 780, "Bassett Lowke", "Traction Engine", "1950s", "David Walmsley", "", 3, "They were sold in kit form by Bassett Lowke by mail order and tended to be modified or enhanced by the builder, so all are not quite the same.", "2013-02-16 15:58:00", 0)

        IE(oC, 781, "Bowman", "E158", "1930s", "David Walmsley", "", 1, "This model is in original play worn condition with it's original box and funnel.", "2013-02-23 17:32:00", 0)

        IE(oC, 782, "Weller", "Aldbury Manor MK4", "c1965", "Roly Williams", "http://rolywilliams.com/weller_am_mk4.html", 1, "Probably made by a pupil at Aldbury Manor school to a design by Geoffrey Weller", "2013-04-07 11:31:00", 0)

        IE(oC, 783, "Weller", "Court Lodge MK1", "c1980", "Roly Williams", "http://rolywilliams.com/weller_cl_mk1.html", 1, "Probably made by a pupil at Court Lodge school to a design by Geoffrey Weller", "2013-04-07 11:31:00", 0)

        IE(oC, 784, "TMY", "Twin", "c1945", "Dan", "", 1, "here is a TMY twin , horizontally opposed , japan , around 1945 , very smooth running , very heavy , seems to be nickel plated .. not much more info other than what i can find on the internet which happens to be very little , any additional info would be greatly appreciated.", "2013-04-07 11:34:00", 0)

        IE(oC, 785, "Bing", "130-232 Double Piston", "1902", "Wim Gregoor (from Arnhem, Holland)", "", 6, "The smokestack was missing, is not original, reconstructed as good as possible; safety-valve looks not to be original, has no weight, had to make one to have it work, hope to find an original one...  Extra note: tile-pattern is unusual, never seen it yet; no Bing logo pressed (or placed) in front wall of the kettle-house", "2013-04-07 11:38:00", 0)

        IE(oC, 786, "DMF Neustadt", "DMF ST02W", "2013", "Camst648", "http://camst648.webs.com/ ", 3, "Water cooled stirling engine. Engine is handbuilt in detail by Peter Gaschler.", "2013-04-08 13:20:00", 0)

        IE(oC, 787, "Markie", "Road Locomotive", "2012", "Camst648", "http://camst648.webs.com/ ", 1, "Handbuilt in detail by Mr Tony Pearce of Tony Pearce Design at Markie Workshop, England.", "2013-04-08 13:25:00", 0)

        IE(oC, 788, "Wiggers", "STIWI 2", "2012", "Camst648", "http://camst648.webs.com/ ", 1, " Handmade Stirling engine of exeptional quality. ", "2013-04-08 13:30:00", 0)

        IE(oC, 789, "PM Research", "SOLAR-12", "2013", "GaryD", "", 5, "The Rider-Ericsson is the only hot air engine that was actually manufactured in production quantities.  This is a water cooled engine with a working water pump just as in the original. A lovely cast metal engine.", "2013-04-15 08:06:00", 0)

        IE(oC, 790, "A. Thieren & Sons", "Cabin Cruiser", "c1950", "Roly Williams", "http://rolywilliams.com/cabin_cruiser.html", 2, "An all wood hull powered by a modified Mamod MM1 engnie. Paintwork is not original.", "2013-04-22 07:57:00", 0)

        IE(oC, 791, "K-D SteamSupreme", "Angelique Vertical", "2013", "Greenmachine", "", 1, "Kevin Doveton also hand crafts horizontal stationary steam engines and Stirling hot air engines in South Africa", "2013-04-22 08:06:00", 0)

        IE(oC, 792, "Weller", "Court Lodge Mk 1", "1975", "75BREDHILL( Alex Davies)", "http://www.75bredhill.weebley.com", 1, "An early model due to bracketed construction instead of one long screw though the middle of the firebox.", "2013-05-21 07:40:00", 0)

        IE(oC, 793, "Mamod", "SE1", "1946", "David Walmsley", "", 1, "This model was made just for a few months in 1946 and is quite rare.  The base was repainted some time ago and the burner is reproduction the rest is original", "2013-06-17 11:21:00", 0)

        IE(oC, 794, "Mamod", "SE1", "1951", "David Walmsley", "", 2, "Was restored some time ago, now play worn again. Reproduction Burner", "2013-06-17 11:25:00", 0)

        IE(oC, 795, "Wilson Foundries", "S2", "???", "Edd Payne", "", 1, "WILSON BRASS AND ALUMINUM FOUNDRIES Ltd  TORONTO CANADA<br>This engine seems to be of all aluminun construction inc the boiler,base,whistle,safety valve ,cylinder&piston,steam pipe and cylinder mount.  The flywheel is bronze and the crank shaft steel.It is spirit fired and is a very nice runner.", "2013-06-17 11:40:00", 0)

        IE(oC, 796, "Microcosm", "4 Cylinder Marine", "March 2013", "Microcosm", "http://stores.ebay.co.uk/Microcosm-Engine", 4, "Note from the editor:  The Chinese creator of this engine asked me to add this as an entry to the bible.  It is very beautiful and I thought it merited being shown here. From the eBAY link I can see he / they sell lots of steam related items, but this is not an endorsement by the TSB of the seller or his items.  (I have no knowledge of them good or bad)", "2013-06-17 11:49:00", 0)

        IE(oC, 797, "Mamod", "SE2", "1950", "David Walmsley", "", 1, "The engine has a reproduction burner", "2013-06-23 11:37:00", 520)

        IE(oC, 798, "Mamod", "SE2", "1954", "David Walmsley", "", 1, "The engine has had the base and engine frame repainted, but the parts are original.", "2013-06-23 11:39:00", 720)

        IE(oC, 799, "Cyldon", "13-4", "c1947", "alan_donna", "", 1, "My lightly restored Cyldon, This engine was produced by Sidney S Bird and sons between 1947 and 1951.", "2013-07-07 08:30:00", 0)

        IE(oC, 800, "Bowman", "M158", "1930s", "David Walmsley", "", 2, "Original engine parts, with box. New paintwork to base and burner.", "2013-07-08 13:31:00", 0)

        IE(oC, 801, "Bowman", "M135", "1930s", "David Walmsley", "", 1, "", "2013-07-08 13:34:00", 0)

        IE(oC, 802, "Gee Cee", "Unknown", "Unknown", "Edd Payne", "", 2, "I got this engine from a friend here in Australia.He got it some years ago at a swap meet with no history.It seems to factory made.  It is a single cylinder oscillating design of all cast bronze.it has a small all silver soldered boiler suspended inside the outer shell held only by the filler plug and the safety valve,there is a air gap all around the boiler and the exhaust vents through the stack. It is spirit fired and runs very well.", "2013-08-01 08:16:00", 0)

        IE(oC, 803, "Wells", "Slide Valve TE", "1908s?", "Verithingeoff", "", 4, "This one is, I think, an Australian built engine, but with a slide valve engine. Built in the 1980's?", "2013-08-01 08:23:00", 0)

        IE(oC, 804, "Graham Industries", "TVR1A", "1991-", "Tom 'Kmot' Keliher ", "", 4, "Supplied either as an assembled, or pre-machined parts kit. I assembled, painted, and polished my engine.", "2013-08-01 08:30:00", 0)

        IE(oC, 805, "Microcosm", "V4 Engine", "15/07/2013", "Microcosm", "http://stores.ebay.co.uk/Microcosm-Engine", 9, "The new V4 engine.   Overall dimensions: (mm)<br/>Bore : 14mm<br>Stroke : 16mm<br>Each cylinder Capacity: 3ml<br>Planetary Gear ratio: 4:1<br>Flywheel diameter : 37mm<br>Output shaft : 5.5mm<br>Other Output shaft :4.5mm<br>O.A. Length : 150mm<br>O.A. Width : 110Mmm<br>O.A. Height : 90mm<br>Net weight : 950G <br>After testing, when the pressure of 4 kg, it can reach speeds above 1200 rpm.", "2013-08-18 10:23:00", 0)

        IE(oC, 806, "Mamod", "MM2", "1949-52", "David Walmsley", "", 2, "Brass Fly wheel model in original play worn condition.", "2013-08-18 10:30:00", 707)

        IE(oC, 807, "Mamod", "MM2", "1949-53", "David Walmsley", "", 3, "Not fired much from new, with original paintwork showing very little wear.  Has lugs to hold the burner in place and the chimney inside is painted.  With original box.", "2013-08-18 10:34:00", 0)

        IE(oC, 808, "Mamod", "SE1", "c1959", "David Walmsley", "", 1, " Was restored using original parts in 2013.  ", "2013-08-18 10:36:00", 0)

        IE(oC, 809, "Bing", "Unknown Upright", "1930s?", "Ian R.", "", 3, " An old engine that my father handed to me and helped set-up  back in the late 50's.  Please contact the site if you have any more information on this model", "2013-08-18 10:37:00", 0)

        IE(oC, 810, "Jensen", "Jensen #20 Big Power Plant", "1946", "Classixs", "http://steamup.dk/", 2, "The 'G' designation, following the modelnumber for plants with generator, didn´t appear until 1992. Up to that point, the Jensen 20 plants carrying a Jensen 15 generator, was know as 'Jensen 20 - Big Power Plant'", "2013-08-27 08:21:00", 0)

        IE(oC, 811, "Jensen", "Cooper Bros. 2508", "1950s", "Classixs", "http://steamup.dk/", 2, "Somewhat rare and quite an oddity, as there seem to be none, or very little info on these re-tagged Jensen 70´s. They were present in the 50´s and 60´s, but no info whether they were nametagged this way directly with Jensen, or simply bought by Cooper Bros. Company N.Y. as Jensen 70, and then renamed. No info either if they were distributed as gifts to company customers, or in reality sold as engines made by Cooper Bros.", "2013-08-27 08:23:00", 0)

        IE(oC, 812, "Jensen", "Cooper Bros. 2508", "1960s", "Classixs", "http://steamup.dk/", 2, "See 1950s model.", "2013-08-27 08:26:00", 0)

        IE(oC, 813, "Jensen", "Jensen #20R", "1960s", "Classixs", "http://steamup.dk/", 2, "Early 1960´s transistion model with the current bricked firebox and the 'old-style' vertical watergauge boiler 'R' standing for Reversed (Engine placed to the left of the boiler on the base, as opposed to the normal right hand position)", "2013-08-27 08:29:00", 0)

        IE(oC, 814, "Microcosm", "M8", "2013", "Robert Graham", "", 2, " This is a small, but very well machined engine. Has a minature wick burner (metho)and it is a good, very lively performer. Comes in a plain wooden box with a few accessories.", "2013-08-30 08:20:00", 0)

        IE(oC, 815, "Hobbies", "SE2", "1935-39", "David Walmsley", "", 3, "In excellent original condition.", "2013-09-01 18:48:00", 0)

        IE(oC, 816, "Markie", "TE Plough engine", "Built 2012-13", "Camst648", "http://camst648.webs.com", 1, "Handmade by Tony Pearce, C. Burrell & Son's 1879 TE Plough engine. Engine is built over a long time period with the most atention to details of a very high standard. 1:10 Scale (1 1/8"") Length of model 64 cm + gas tank trailer. ", "2013-09-03 08:40:00", 0)

        IE(oC, 817, "Markie", "Balance Plough", "Built 2013", "Camst648", "http://camst648.webs.com", 1, "Handmade by Tony Pearc.  Total length is 70 centimeters. ", "2013-09-03 08:43:00", 0)

        IE(oC, 818, "Kleinemeier", "ZZD", "2013", "Camst648", "http://camst648.webs.com", 1, "", "2013-09-03 08:48:00", 0)

        IE(oC, 819, "David Auld", "Marine Engine", "1990s?", "Grotto", "http://www.mshimbamshamba.co.nz", 4, "", "2013-09-07 13:57:00", 0)

        IE(oC, 820, "David Auld", "Vertical Engine (Modified)", "1990s?", "Grotto", "http://www.mshimbamshamba.co.nz", 1, "A David Auld vertical engine which has been inserted into a scratch built (using some Mamod parts) rail wagon.  Believed to have been modified by Colin Burleigh 1998.", "2013-09-07 13:59:00", 0)

        IE(oC, 821, "Reeves", "Popular Ocsillating Engine", "2013", "SwiftFox", "http://swiftfoxsteamco.webs.com/", 4, "I believe this engine has been in production since the 1940’s, it is made mostly from gunmetal sand castings, the engine is double acting and quite powerful for its size. I’ve included a photo of the raw castings as received from Reeves 2000 (formally A.J Reeves of Birmingham)and a few shots of the finished engine mounted on a mahogany plinth.", "2013-09-26 12:43:00", 0)

        IE(oC, 822, "Stuart Turner", "ST Ocsillator", "2013", "SwiftFox", "http://swiftfoxsteamco.webs.com/", 3, "This is the modern version of the venerable Stuart ‘S.T’ oscillating engine that has been in constant production for over 80 years, the new engine has a hot stamped brass frame and extruded brass cylinders instead of the sand cast gunmetal of the originals. The cylinder has studs and nuts instead of the old cheesehead screws. I’ve included a photo of the raw parts along with the finished engine.", "2013-09-26 12:49:00", 0)

        IE(oC, 823, "Stuart Turner", "7A", "???", "St. Paul Steam, Bruce", "", 1, "Height: 7 1/2 Inches,  Flywheel diameter: 3 1/2 Inches   Cylinder Bore: 1 Inch Diameter,   Cylinder Stoke:  1 Inch", "2013-09-26 12:55:00", 0)

        IE(oC, 824, "Ind-X", "Electric", "???", "Grotto", "http://www.mshimbamshamba.co.nz", 2, "", "2013-09-26 13:00:00", 0)

        IE(oC, 825, "Weeden", "900", "???", "Grotto", "http://www.mshimbamshamba.co.nz", 2, "As found needs cleaning up and a little work.", "2013-09-26 13:04:00", 0)

        IE(oC, 826, "Steamcraft", "Vertical", "2001", "Grotto", "http://www.mshimbamshamba.co.nz", 2, "May be based on plans from Tubal Cain's book.", "2013-09-29 18:15:00", 0)

        IE(oC, 827, "Stuart Turner", "Score", "1983", "Grotto", "http://www.mshimbamshamba.co.nz", 4, " Constructed by Ray L. Edgar", "2013-09-29 18:18:00", 0)

        IE(oC, 828, "Hawker", "Cygnet M13", "???", "Grotto", "http://www.mshimbamshamba.co.nz", 2, " Built from Plans", "2013-09-29 18:23:00", 0)

        IE(oC, 829, "Bassett Lowke", "No.1 Size Tangye", "1912", "Grotto", "http://www.mshimbamshamba.co.nz", 4, "No. 1 size ""Tangye"" type horizontal engine. Cylinder is 1/2"" bore * 5/8"" stroke.  Coupled to a No. 1 Model Babcock & Wilcox Water-Tube Boiler which includes Pressure Gauge & Siphon Pipe, Water Gauge, Safety Valve, Filler, Union Stop Valve, Superheater Pipe, & Chimney.  Castings of the boiler, and the flywheel are cast iron.  Boiler is solid drawn copper tube with gun-metal ends, boiler and water tubes are brazed, and guaranteed to withstand safely a pressure of 100lbs. per square inch.", "2013-09-29 18:35:00", 0)

        IE(oC, 830, "Doll", "Grinder", "?", "Grotto", "http://www.mshimbamshamba.co.nz", 1, "", "2013-09-29 18:38:00", 0)

        IE(oC, 831, "Doll", "Fret Saw", "?", "Grotto", "http://www.mshimbamshamba.co.nz", 1, "", "2013-09-29 18:39:00", 0)

        IE(oC, 832, "Bing", "Superforce Locomotive", "c1926", "Grotto", "http://www.mshimbamshamba.co.nz", 3, "Awaiting work", "2013-09-29 18:44:00", 0)

        IE(oC, 833, "Wilesco", "D18", "2003-13", "Curryfun", "", 3, "Steam plant wiht generator to light up one lamppost", "2013-10-21 08:16:00", 0)

        IE(oC, 834, "Hobbies", "SE3", "1930s", "David Walmsley", "", 1, "A very good example of this model in original play-worn condition", "2013-10-21 08:19:00", 0)

        IE(oC, 835, "Stuart Turner", "10V", "2013", "Swift Fox", "http://swiftfoxsteamco.webs.com", 2, "Probably the most popular engine in the current Stuart range, this well machined example has a few extras fitted including cylinder drain cocks, displacement lubricator and a cast iron pulley fitted to the crankshaft to run accessories, it runs on very low steam pressure and is a very smooth and quiet runner.", "2013-10-21 08:25:00", 0)

        IE(oC, 836, "Kontax", "KS18 Beta-Type Stirling engine", "2013", "Camst648", "http://camst648.webs.com/", 4, "", "2013-11-06 22:00:00", 0)

        IE(oC, 837, "Wilesco", "H110 Stirling with generator", "2013", "Camst648", "http://camst648.webs.com/", 4, "", "2013-11-06 22:05:00", 0)

        IE(oC, 838, "Bing", "Unknown", "???", "Steve Conescu", "", 4, "Unknown but looking at the base plate of the 130-275 it is the same pattern so assume it would be around the 1909 mark.", "2013-12-11 20:55:00", 0)

        IE(oC, 839, "Marklin", "4149 5.5", "1919", "Earlytimes", "", 3, " This engine was one family owned since new until I acquired it. It came to the US from Germany by way of Steam liner in the late 1920's.  A robust little engine in wonderful condition. ", "2013-12-11 21:01:00", 0)

        IE(oC, 840, "Wormar", "Trojan Model D", "1926-27", "Colin Hewitt", "", 3, "This is a nice example in good play worn condition complete with original flat top meths burner (burner missing the correct non vented filler cap, this has been resolved).  Notice the Jenkins patent stamped under the Wormar Brand on the mounting plate. Piston rod painted green and engine frame painted blue, I believe these to be the original colours.  ", "2013-12-11 21:16:00", 0)

        IE(oC, 841, "SIM Co", "No 40 Watt Junior", "1947", "Greg Basta", "", 4, " These were made in Pittsburgh, PA. by the Specialty Instrument and Machine Company and later models were distributed by the Harvey Miller Corporation.  Double acting, bore and stroke are both 15/16"".  Boiler 3"" X 6"".  Electrically heated by a 500 watt coiled rod, beneath the boiler. ", "2013-12-11 21:37:00", 0)

        IE(oC, 842, "Merkur Toys", "Steam Engine Medium", "2005", "Greg Basta", "", 3, "Pellet or alcohol fired ", "2013-12-11 22:08:00", 0)

        IE(oC, 843, "Reeves", "Mary Beam Engine", "1965", "David Walmsley", "", 1, "Made from unmachined castings.", "2013-12-11 22:12:00", 0)

        ' IE(oC, 844, "Stuart Turner", "Steam Hammer", "???", " St. Paul Steam, Bruce", "", 1, " Stuart Turner 'Steam Hammer' with model shelter house", "2013-12-11 22:12:00", 0)

        IE(oC, 845, "Microcosm", "M6-B", "2013", "Roly Williams", "http://rolywilliams.com/microcosm_M6-B.html", 2, "The M6-B is similar to a scaled up version of the Jenny Wren - 115mm tall", "2013-12-15 18:35:00", 0)

        IE(oC, 846, "Karsten Gintschel", "Radial Turbine", "Feb 2011", "CurryFun", "", 3, "Concept version, only made 9 turbines of this concept made.", "2013-12-21 17:05:00", 0)

        IE(oC, 847, "Stuart Turner", "S-50 Mill Engine", "2013", "SwiftFox", "http://swiftfoxsteamco.webs.com/", 2, "This is the current version of the Stuart S50 which is an attractive scale model of a typical single cylinder non condensing mill engine. This example features a cast iron cylinder/valve chest, the older model of which several examples can be seen above used gunmetal for these parts.", "2013-12-22 17:35:00", 0)

        IE(oC, 848, "Stuart Turner", "Meteor", "1930s", "Phil Morgan", "", 3, "Cost new in the 1930's - 18s 6d  size - Height 3 3/4 inches length 2 3/4 inches width 1 7/8 inches Bore 7/16 inch Stroke 7/16.", "2013-12-23 14:55:00", 0)

        IE(oC, 849, "Bing", "130-272", "1912", "Earlytimes", "", 4, "   Nice example of this model.  Very attractive details and coloring with a Tin lithographed tiled top on wooden base. Boiler surround has a gunmetal blue tone.", "2013-12-28 17:21:00", 0)

        IE(oC, 850, "David Auld", "SE3", "c1996", "Nicolas #1Steam", "", 4, "David Auld SE3 steam engine, red boiler. As far as I know there were 50 of these made, along with 370 with the blue boiler and 3 with a green boiler.", "2014-01-02 17:01:00", 0)

        IE(oC, 851, "CAMEO", "Unknown", "Unknown", "Kevin", "", 3, "A copy of the Bowman M158", "2014-01-09 11:40:00", 0)

        IE(oC, 852, "CAREAST", "Unknown", "c1946", "Kevin", "", 2, "Nothing known of the company", "2014-01-09 11:43:00", 0)

        IE(oC, 853, "Castle Products", "No. B", "c1955", "Kevin", "", 4, "Nothing known of the company other than it operated from 20 Wilmot Road, Leyton, London E10", "2014-01-09 11:46:00", 0)

        IE(oC, 854, "Cyldon", "13-5", "c1950", "Kevin", "", 1, "Manufactured in Enfield, Middlesex, England between 1947 and 1951 (1953 some sources say) by Sydney S Bird & Sons", "2014-01-09 11:47:00", 0)

        IE(oC, 855, "Cyldon", "13-4", "c1950", "Kevin", "", 1, "Manufactured in Enfield, Middlesex, England between 1947 and 1951 (1953 some sources say) by Sydney S Bird & Sons", "2014-01-09 11:47:00", 0)

        IE(oC, 856, "Cyldon", "13-2", "c1950", "Kevin", "", 1, "Manufactured in Enfield, Middlesex, England between 1947 and 1951 (1953 some sources say) by Sydney S Bird & Sons", "2014-01-09 11:47:00", 0)

        IE(oC, 857, "Stuart Turner", "Victoria Mill Engine", "???", "David Walmsley", "", 2, "15.5"" long, 7"" Flywheel 1"" Bore 2"" stroke.   The large flywheel allows the engine to run smoothly at low speeds where the long elegant stroke can be appreciated. ", "2014-01-09 18:15:00", 0)

        IE(oC, 858, "Wells", "TE School Engine", "???", "Kevin", "", 2, "Twin version made from the Kenneth Wells Plans including extensive use of brass", "2014-01-12 10:25:00", 0)

        IE(oC, 859, "Mastrand", "Steam Roller", "c1950", "Kevin", "", 1, "Restored in 2013, believed to be the earlier version.", "2014-01-12 10:28:00", 0)

        IE(oC, 860, "DGM", "Model 4B", "???", "Kevin", "", 3, "Nothing known about this British engine.", "2014-01-12 10:30:00", 0)

        IE(oC, 861, "Unknown", "Basil Hartley", "???", "Kevin", "", 3, "Another example of the 'unknown English' engine mentioned in Basil Hartleys book. All the dimensions and threads are imperial.  ", "2014-02-03 20:14:00", 0)

        IE(oC, 862, "Swan", "M1", "1920-25", "Kevin", "", 3, "Made in England between 1920 and 1925 (circa 1916 some sources say)  by the Hobran engineering company ltd of Wolverhampton.", "2014-02-03 20:18:00", 0)

        IE(oC, 863, "Quality", "Model Number 1", "???", "Kevin", "", 1, "I know nothing about this British engine, post war for sure and has been called the  Quality Models Number 1", "2014-02-03 20:21:00", 0)

        IE(oC, 864, "Empire", "43", "1950s", "SteamN", "", 1, "Nickel Plated. Manufactured in the 1950's and is stamped on the bottom ""CAT. NO. 43"" and is rated 120 volts, 350 watts.  The engine is in good working condition and runs very well.", "2014-02-03 20:26:00", 0)

        IE(oC, 865, "Empire", "43", "???", "SteamN", "", 7, "Manufacture date unknown. It only has ""43"" and 115 volts, 400 watts stamped on the bottom.  The heating element does not work, but it runs well on air.   The base plates measure 8 x 6 1/4 inches on both. #1 is a darker red then #2.  Both boilers are approximately 6 3/4 inches long and 2 1/2 inches in diameter, though engine #1 has a thicker cap on the sight glass end. Both have a smooth finish on the back side of the boiler with no cap. Both measure 6 3/4 inches tall from the bottom of the base to the top of the stack.   Both have the pressure relief valve located in the stack.  Some of the major differences between the two are as follows:  Whistle placement, on #1 is towards the back of the boiler just in front of the stack, where as on engine #2 it is centered between the flue and steam regulating valve.   The whistles are just under 2 inches tall. #1 has a flat top where #2 is domed there are also other minor changes between the two.  Throttle knobs on both engines are made of red ""Bakelite"" but each has a different design. #2 having more of a mushroom shape.  Engine #1 has a round piston rod connected to the flywheel that pivots at the piston. #2 has a flat connecting rod from the flywheel that connects to the piston rod and there is a dome on the cylinder where the rod enters the piston. One piece cast cylinder and steam chest on both.  If anyone has more information about these engines, please contact me David aka. ""SteamN"" at geosearchn@gmail .com", "2014-02-03 20:30:00", 0)

        IE(oC, 866, "Unknown", "Bottle Frame", "???", "Kevin M", "", 3, "I bought this bottle framed steam engine recently on an online auction. It is missing the upper half (cylinder, piston, steam chest, etc) and has no name or markings on it. I have seen and own many model steam engines but have never seen one like this before and am hoping to find information about it. It was bought from a guy in New Jersey and he did not tell me anything more. Unusual flywheel not flat surface but rounded, 3 inch diameter. Piston stroke is 1 1/4 inches. Belt pulley has three sizes. As is it is 6 inches tall and where the piston attached is 1 3/32 across. I seem to think it is from an old popcorn cart possibly but I don't know. Any information on this engine would be great, please contact subtsb@gmail.com with any info thanks.", "2014-02-03 20:35:00", 0)

        IE(oC, 867, "Bowman", "265 Loco", "c1930s", "John M. Melnick", "", 8, "Locomotive has been refurbished to operating condition.     ", "2014-02-03 20:38:00", 0)

        IE(oC, 868, "Mamod", "SP2", "1980", "Secret Anorak", "http://www.mamodoverhaul.com", 2, "A 1980 model SP2, this was restored after siting in a damp shed for many years. The owner gave it to me after realizing I'm Interested in old mechanical things. I covered the restoration on my website www.mamodoverhaul.com and currently have a few more projects lined up.", "2014-02-03 20:42:00", 0)

        IE(oC, 869, "Karsten Gintschel", "Diablo Turbine", "2013", "CurryFun", "", 3, " Turbine with the looks of the 'devil'.", "2014-02-03 20:46:00", 0)

        IE(oC, 870, "Mersey Model Co Ltd", "Unknown", "c1935", "Paul_C", "http://modelsteam.myfreeforum.org/ftopic70476-0-asc-0.php", 5, "This is a Mersey engine of date and model unknown,possibly 1935.  See the linked thread for more information", "2014-02-22 17:31:00", 0)

        IE(oC, 871, "Unknown", "Unknown #7", "???", "RDickens", "", 4, "Unknown engine,  please contact us if you have any more information.  Update from Jeffery Bicht:  ""This engine is a Robert Fulton made in USA and have a steel boiler like all the Robert Fulton's I know about" + Chr(34), "2014-02-22 17:37:00", 0)

        IE(oC, 872, "Unknown", "Unknown #8", "???", "RDickens", "", 4, "Unknown engine,  please contact us if you have any more information. Update from Jeffery Bicht:  ""This engine is a Robert Fulton made in USA and have a steel boiler like all the Robert Fulton's I know about" + Chr(34), "2014-02-22 17:37:00", 0)

        IE(oC, 873, "PM Research", "#3 Mill Engine", "2013", "Swift Fox", "http://swiftfoxsteamco.webs.com", 3, "This is a machined kit version featuring a cast iron base and bronze cylinder, the engine was assembled by myself. I have included a photo of the raw parts before assembly as well as the finished model.", "2014-02-22 17:55:00", 0)

        IE(oC, 874, "Stuart Turner", "Beam Engine", "c1984", "David Walmsley", "", 2, "The 500 boiler is the boiler Stuarts recommend to drive the Beam Engine.", "2014-02-23 08:05:00", 0)

        IE(oC, 875, "Jensen", "Jensen #55", "1980-1", "Nick", "", 4, "", "2014-02-23 08:08:00", 0)

        IE(oC, 876, "Falk", "143-3", "1930", "Steamfarmer", "", 5, "", "2014-02-23 08:10:00", 0)

        IE(oC, 877, "Cyldon", "13-1", "1940s-1950s", "Kevin", "", 1, "Early and later versions of the 13-1", "2014-02-24 08:00:00", 0)

        IE(oC, 878, "Mamod", "Limousine (1403B)", "1999", "Camst648", "http://camst648.webs.com/", 2, "", "2014-03-04 07:40:00", 0, "http://www.youtube.com/user/Camst648/videos?flow=grid&view=0")

        IE(oC, 879, "Kleinemeier", "Lokomobile Overhead", "2013", "Camst648", "http://camst648.webs.com/", 2, "", "2014-03-04 07:45:00", 0, "http://www.youtube.com/user/Camst648/videos?flow=grid&view=0")

        IE(oC, 880, "Kleinemeier", "ZZD Horizontal Boiler", "2013", "Camst648", "http://camst648.webs.com/", 2, "", "2014-03-04 07:46:00", 0, "http://www.youtube.com/user/Camst648/videos?flow=grid&view=0")

        IE(oC, 881, "Markie", "Showman Caravan", "2013", "Camst648", "http://camst648.webs.com/", 1, " Made on comission by Mr Tony Pearce at Markie.  Scale 1:10", "2014-03-04 07:48:00", 0, "http://www.youtube.com/user/Camst648/videos?flow=grid&view=0")

        IE(oC, 882, "Markie", "Scenic Showman Engine", "2013", "Camst648", "http://camst648.webs.com/", 3, " Handmade by Mr Tony Pearce at Markie workshop, Fareham UK in 2013.  Scale 1:10", "2014-03-04 07:48:00", 0, "http://www.youtube.com/user/Camst648/videos?flow=grid&view=0")

        IE(oC, 883, "Bindon", "Micro Steam Turbine Car", "2014", "Greenmachine", "", 1, "Prof Jeff Bindon of University of KZN in Natal designed the kits and also does Pop Pop boats.  This Bindon Micro Steam Turbine Car was built by Greenmachine from a kit in 2014", "2014-03-22 09:53:00", 0, "")

        IE(oC, 884, "Tony Green", "Unit Steam Engine", "???", "Roly Williams", "http://rolywilliams.com/tony_green_use.html", 3, "This engine comes as a kit of parts to make a single cylinder engine. It is designed to be easily combined in multi cylinder configurations.", "2014-03-22 10:03:00", 0, "")

        IE(oC, 885, "Stuart Turner", "OH1", "2013", "Swift Fox", "http://swiftfoxsteamco.webs.com", 3, "This engine was produced by Stuart for a short time in the 1930’s and it was part of a range of six engines under the ‘Progress’ name. In 2013 Stuart reintroduced the OH1 as a set of castings to machine, the only difference between the new model being that the cylinder/covers and engine standard are made of cast iron instead of the gunmetal of the original.", "2014-04-12 17:25:00", 0)

        IE(oC, 886, "Microcosm", "M22", "2014", "Roly Williams", "http://rolywilliams.com/microcosm_m22.html", 3, "", "2014-04-18 10:49:00", 0, "")

        IE(oC, 887, "Falk", "483-3", "1928-30", "Roly Williams", "http://rolywilliams.com/falk_483-3.html", 4, "", "2014-04-18 10:55:00", 0, "")

        IE(oC, 888, "Bing", "130-280", "1924-33", "Gary Doty", "", 11, "A date estimate of 1924-1933 is based on the logo design", "2014-04-22 13:20:00", 0, "")

        IE(oC, 889, "H.E. Boucher Mfg Co", "Steam Boat", "1925", "Gordan R", "", 2, " H.E. Boucher steam boat built in 1925 and reconditioned in the 1950's it was my fathers.", "2014-05-13 14:00:00", 0, "")

        IE(oC, 890, "Kleinemeier", "Custom Vertical", "2014", "Giles K (France)", "", 6, "I bought a Kleinemeier  vertical boiler steam engine in January 2014 with a special option.   Water level glass gauge.", "2014-05-13 14:10:00", 0, "")

        IE(oC, 891, "Bindon", "Pop pop boat kit", "2014", "Greenmachine", "", 1, " This is a Pop Pop boat kit of materials to make the engine and boat hull by Jeff Bindon.  The original engine had a clear plastic diaphragm.", "2014-05-21 11:18:00", 0, "")

        IE(oC, 892, "Bindon", "Hero Steam Turbine Kit", "2014", "Greenmachine", "", 1, "This is a Steam Turbine kit of materials to make the boiler and stand/burner by Jeff Bindon.  The jacket around the boiler is to prevent burnt fingers.", "2014-05-21 11:20:00", 0, "")

        IE(oC, 893, "K-D SteamSupreme", "Lady Jade Horizontal", "2013", "Greenmachine", "", 1, "Lady Jade Horizontal steam engine with matching table saw.", "2014-05-21 11:25:00", 0, "")

        IE(oC, 894, "Karsten Gintschel", "Tornado Oil Pump", "2014", "Curryfun", "", 3, "Ölfeldpumpe.   It is possible to run the oil jack with the Tornado turbine or you can choose the battery option.  There are some batteries built into the oil jack to provide power for the electric motor. ", "2014-07-13 18:37:00", 0, "")

        IE(oC, 895, "Karsten Gintschel", "Tornado Models", "2014", "Curryfun", "", 2, "The complete range of Tornado models", "2014-07-13 18:47:00", 0, "")

        IE(oC, 896, "Anton Bohaboy", "Marine Engine", "c1940-50", "Stephen W", "", 6, "", "2014-07-13 19:04:00", 0, "")

        IE(oC, 897, "Anton Bohaboy", "Marine Engine and Boiler", "c1940-50", "Stephen W", "", 5, "", "2014-07-13 19:05:00", 0, "")

        IE(oC, 898, "Jean Comby", "Twin Cylinder", "???", "Jeffery B", "", 3, "", "2014-07-13 20:02:00", 0, "")

        IE(oC, 899, "Jean Comby", "Horizontal #2", "???", "Jeffery B", "", 3, "This one is one of what I think is the last or newest ones made do to the paint and Uins sticker", "2014-07-13 20:06:00", 0, "http://www.youtube.com/user/Jeff46u/videos")

        IE(oC, 900, "Jensen", "Jensen #15E", "1990s", "Jeffery B", "", 1, "Here is a Jensen #15E they made for a very short time. They used a Erector set electric motor to make these. They did not make them very long. Era around the late 1990s.", "2014-07-14 08:10:00", 0, "")

        IE(oC, 901, "Robert Fulton", "Horizontal", "???", "Roly Williams", "http://rolywilliams.com/marvindustries_horizontal.html", 1, "Also known as  Marvindustries ", "2014-07-18 14:07:00", 0, "")

        IE(oC, 902, "T.E.Haynes", "Steam Engine", "???", "Roly Williams", "http://rolywilliams.com/haynes_steam_engine.html", 1, "Probably made in a school metalworking class using plans published by T.E.Haynes", "2014-07-18 14:12:00", 0, "")

        IE(oC, 903, "Wilesco", "D10el", "???", "Roly Williams", "http://rolywilliams.com/wilesco_d10el.html", 1, "This is the 115V electrically heated version of the D10.", "2014-07-18 14:16:00", 0, "")

        IE(oC, 904, "Hobbies", "SE1", "1936", "David Walmsley", "", 3, "Complete with box and in unrestored condition", "2014-07-18 14:22:00", 0, "")

        IE(oC, 905, "Wilson Bros", "Large and Small", "c1948", "Kevin", "", 2, "Wilson Brothers of Woodward Road, Kirkby Trading Estate, Liverpool made two vertical engines circa 1948.", "2014-07-29 07:40:00", 0, "")

        IE(oC, 906, "Bowmans of Luton", "PW201", "1945-49", "Kevin", "", 3, "Refurbished.", "2014-07-29 07:42:00", 0, "")

        IE(oC, 907, "Bowmans of Luton", "PW202", "1945-49", "Kevin", "", 1, "Refurbished.", "2014-07-29 07:44:00", 0, "")

        IE(oC, 908, "Bowmans of Luton", "PW203", "1945-49", "Kevin", "", 1, "Refurbished.", "2014-07-29 07:44:00", 0, "")

        IE(oC, 909, "Burnac", "Vulcan", "1946-49", "Kevin", "", 2, "Burnac Ltd, Burslem, Stoke-on-Trent are known for this single vertical engine called the Vulcan. Two different types of level gage are known. ", "2014-07-29 07:49:00", 0, "")

        IE(oC, 910, "Cyldon", "13-3", "1940s-50s", "Kevin", "", 1, "", "2014-07-29 07:51:00", 0, "")

        IE(oC, 911, "Cotswold Heritage", "Cirrus Beam", "2013", "Verithingeoff", "http://www.verithingeoff.com", 4, "Built from a kit and powered by a MCA boiler.", "2014-07-29 07:55:00", 0, "")

        IE(oC, 912, "Jensen", "Jensen #70", "1950s", "Jeff46U", "http://www.youtube.com/user/Jeff46u/videos", 2, "Earlier wooden base version", "2014-07-29 08:01:00", 0, "")

        IE(oC, 913, "Jensen", "Jensen #30", "1960s", "Jeff46U", "http://www.youtube.com/user/Jeff46u/videos", 2, "Earlier wooden base version", "2014-07-29 08:03:00", 0, "")

        IE(oC, 914, "Jensen", "Jensen #30", "1980s", "Jeff46U", "http://www.youtube.com/user/Jeff46u/videos", 2, "", "2014-07-29 08:04:00", 0, "")

        IE(oC, 915, "C.Walker", "Walking Beam Engine", "c1950s", "Stephen W", "", 4, " Engine hails from Sussex, UK. It bares the name 'C.Walker' engraved on a brass name plate it's base, and is of tremendous craftsmanship and made with the highest quality materials. It is a walking Beam Engine built with Machined steel, Brass, Copper and Cast. The Flywheel is 9 1/4"" in diameter, stands 14 1/2"" at it's peak, and 16 1/2 X 9"" at the base, which is constructed of Oak. It weighs 29Lbs. Very intricate Flyball Governor, Displacement Oiler, Pressure Relief Valve and 12 oil ports throughout. I got it turning on 5psi with Air. I was told by a significant collector the world over fashioned after a British Merry Engine. Cir. 1800's", "2014-08-23 10:35:00", 0, "")

        IE(oC, 916, "Doll", "320-4", "1920s", "Marc Robertson", "www.mrphoto.com.au", 5, "This is a basically original 1920’s Doll D.C. model 320/4, single cylinder, Vertical steam engine with weighted safety valve, boiler sight glass, pressure gauge, whistle and burner all on a cast iron base.   The model number is helpefully stamped on the underside of the base.", "2014-08-23 10:40:00", 0, "")

        IE(oC, 917, "Bing", "10-16-4", "1930s", "Marc Robertson", "www.mrphoto.com.au", 4, "This engine has a replacement flywheel.", "2014-08-23 10:42:00", 0, "")

        IE(oC, 918, "T.E.Haynes", "Steam Engine", "???", "Kevin", "", 2, "From T.E.Haynes Book 1", "2014-08-23 10:44:00", 0, "")

        IE(oC, 919, "T.E.Haynes", "Hot Air Engine", "???", "Kevin", "", 2, "From T.E.Haynes Book 2", "2014-08-23 10:46:00", 0, "")

        IE(oC, 920, "PM Research", "Peanut Rider", "2006", "Camst648", "http://camst648.webs.com/", 1, "", "2014-08-23 10:48:00", 0, "")

        IE(oC, 921, "Bengs Modellbau", "Modified Nick Falme Gulper", "2013", "Camst648", "http://camst648.webs.com/", 2, "Heavily modded Bengs casting by a Canadian who wish to remain anonymous.", "2014-08-23 10:50:00", 0, "http://www.youtube.com/user/Camst648/videos?flow=grid&view=0")

        IE(oC, 922, "Kleinemeier", "KMV Mini Vertical", "2014", "Camst648", "http://camst648.webs.com/", 1, "Number 5 of 5 that will ever be made, also first ever KMV model that is made on wooden base from the manufacturer.", "2014-08-23 11:00:00", 0, "http://www.youtube.com/user/Camst648/videos?flow=grid&view=0")

        IE(oC, 923, "Jensen", "Jensen #75 Meths Fired", "1950s", "paul_c", "", 5, "Here we have an early 1950's Jensen meths fired 75 steam engine.  This engine is the only meths fired Jensen to be made.  Distinguishable by the air vent holes in the firebox sides and no stack fitted to the rear.  Engine unit was later used on the Jensen 70 models, has an electric model plate fitted but is stamped with the model designation 75.  Meths burner is made of tin with a cork stopper, it is rare to find a Jensen 75 still with its burner.", "2014-08-23 11:03:00", 0, "")

        IE(oC, 924, "Wells", "Stationary", "c1970s", "Roly Williams", "http://rolywilliams.com/wells_stationary_2.html", 2, "This example used the bent steel engine frame option", "2014-08-23 11:06:00", 0, "")

        IE(oC, 925, "Anton Bohaboy", "Hotair Engine", "c1950s", "Stephen W", "", 3, "", "2014-09-01 17:22:00", 0, "")

        IE(oC, 926, "Swan", "M2", "c1920s", "Kevin", "", 2, "Made in England between 1920 and 1925 (circa 1916 some sources say) by the Hobran engineering company ltd of Wolverhampton.  I believe the M2 came with a wood base like this to start with and later with a metal base.", "2014-09-01 17:24:00", 0, "")

        IE(oC, 927, "Liney Machine", "Thimble", "2014", "Kevin", "", 1, "", "2014-09-01 17:26:00", 0, "")

        IE(oC, 928, "Elmer Verburg", "Tiny #23", "2014", "Kevin", "", 1, "From Elmer Verburg published plans", "2014-09-01 17:29:00", 0, "")

        IE(oC, 929, "Hobbies", "SE4", "1920s", "David Walmsley", "", 3, "The engine is in original playworn condition. It is unusal that it does not have the oiler or whistle and is probably an early version.", "2014-09-01 17:36:00", 0, "")

        IE(oC, 930, "Markie", "Little Gem Roller", "2014", "Camst648", "http://camst648.webs.com/", 2, "Made by Marie & Tony Pearce at Markie workshop in Fareham, England.", "2014-09-14 19:50", 0, "http://www.youtube.com/user/Camst648/videos?flow=grid&view=0")

        IE(oC, 931, "Kleinemeier", "KMV Overhead Flywheel Engine", "2014", "Camst648", "http://camst648.webs.com/", 2, "", "2014-09-14 19:55:00", 0, "http://www.youtube.com/user/Camst648/videos?flow=grid&view=0")

        IE(oC, 932, "SEIG", "Stirling Engine Type 1", "Unknown (See notes)", "Camst648", "http://camst648.webs.com/", 2, "The model was made in China with severe design flaws that prevent these models from actually working as intended. This engine you see here has been radically remade and designed by David N Jones in 2013 so that it is a fine runner.", "2014-09-14 20:00:00", 0, "http://www.youtube.com/user/Camst648/videos?flow=grid&view=0")

        IE(oC, 933, "Bittleston", "The Bittleston Steam Engine", "January 2009", "Roly Williams", "http://rolywilliams.com/bittleston_steam_engine.html", 2, "The Bittleston Steam Engine, only ever known as such, was made as a small batch as a demonstration of their CNC capabilities", "2014-09-14 20:11:00", 0, "")

        IE(oC, 934, "Liney Machine", "RV-1", "2014", "Kevin", "", 4, "Modified to remove 'cooling fins' and add oilers.", "2014-09-14 20:24:00", 0, "")

        IE(oC, 935, "Bittleston", "The Bittleston Steam Engine", "January 2009", "Kevin", "", 3, "From a one off run of a 1000 units by Bittleston Ltd, Mamod SV for scale.", "2014-09-26 21:07:00", 0, "")

        IE(oC, 936, "Stuart Turner", "No 9", "Aug 2014", "Geoff Walton", "http://www.verithingeoff.com", 4, "Engine built by a guy in New South Wales, a very skilled machinist, a superb build ", "2014-10-15 10:57:00", 0, "")

        IE(oC, 937, "Reeves", "Popular", "", "Kevin", "", 1, "Available as a set of castings since the 1940’s", "2014-10-15 11:01:00", 0, "")

        IE(oC, 938, "Stuart Turner", "ST Oscillator", "1920s-30s", "Kevin", "", 3, "An early version", "2014-10-15 11:04:00", 0, "")

        IE(oC, 939, "Bowman", "Snipe", "c1925", "Geoff Walton", "http://www.verithingeoff.com", 5, "", "2014-10-15 11:09:00", 0, "")

        IE(oC, 940, "K-D SteamSupreme", "Angelique Vertical", "2014", "K-D SteamSupreme", "", 1, "Engine created in South Africa by Kevin Doveton", "2014-10-15 11:19:00", -1, "")

        IE(oC, 941, "K-D SteamSupreme", "Jenna", "2014", "K-D SteamSupreme", "", 1, "Engine created in South Africa by Kevin Doveton", "2014-10-15 11:20:00", 0, "")

        IE(oC, 942, "K-D SteamSupreme", "Lady Jade Horizontal", "2014", "K-D SteamSupreme", "", 1, "Engine created in South Africa by Kevin Doveton", "2014-10-15 11:21:00", -1, "")

        IE(oC, 943, "K-D SteamSupreme", "Stirling", "2014", "K-D SteamSupreme", "", 1, "Engine created in South Africa by Kevin Doveton", "2014-10-15 11:22:00", 0, "")

        IE(oC, 944, "K-D SteamSupreme", "Model 149 with Searchlight", "2014", "K-D SteamSupreme", "", 2, "Engine created in South Africa by Kevin Doveton, a limited edition made on request.", "2014-10-15 13:22:00", 0, "")

        IE(oC, 945, "K-D SteamSupreme", "Beam Engine", "2014", "K-D SteamSupreme", "", 1, "Engine created in South Africa by Kevin Doveton, a limited edition made on request.", "2014-10-19 09:22:00", 0, "")

        IE(oC, 946, "K-D SteamSupreme", "Piston Valve Engine", "2014", "K-D SteamSupreme", "", 1, "Engine created in South Africa by Kevin Doveton, a limited edition made on request.", "2014-10-19 09:23:00", 0, "")

        IE(oC, 947, "K-D SteamSupreme", "Pee Wee Engine", "2014", "K-D SteamSupreme", "", 1, "Engine created in South Africa by Kevin Doveton, a limited edition made on request.", "2014-10-19 09:24:00", 0, "")

        IE(oC, 948, "K-D SteamSupreme", "Hot Air Beam Engine (with pump)", "2014", "K-D SteamSupreme", "", 1, "Engine created in South Africa by Kevin Doveton, a limited edition made on request.", "2014-10-19 09:25:00", 0, "")

        IE(oC, 949, "K-D SteamSupreme", "MK4 Engine (with generator)", "2014", "K-D SteamSupreme", "", 1, "Engine created in South Africa by Kevin Doveton, a limited edition made on request.", "2014-10-19 09:26:00", 0, "")

        IE(oC, 950, "Rose Boats", "Steamer, Julie A", "1992", "Alan Raubenheimer", "", 1, "Fitted with two candle fired diaphragm pop-pop. ", "2014-10-26 19:28:00", 0, "")

        IE(oC, 951, "Rose Boats", "Steamer, Jade A", "1992", "Alan Raubenheimer", "", 1, "Fitted with two candle fired diaphragm pop-pop. ", "2014-10-26 19:34:00", 0, "")

        IE(oC, 952, "Rose Boats", "Steamer, Mary G", "1992", "Alan Raubenheimer", "", 1, "Fitted with two candle fired diaphragm pop-pop. ", "2014-10-26 19:36:00", 0, "")

        IE(oC, 953, "Rose Boats", "Titanic", "2013", "Alan Raubenheimer", "", 1, "A one-off model made for my Rose Boats collection.  It has two of my standard candle fired diaphragm pop-pops.  Length app. 40 cms.", "2014-10-26 19:37:00", 0, "")

        IE(oC, 954, "Rose Boats", "Early Atlantic Steamer, Victoria", "c1989", "Alan Raubenheimer", "", 1, " Fitted with 3 spirit-fired coil pop-pops..  Length overall, approx. 46 cms.", "2014-10-26 19:39:00", 0, "")

        IE(oC, 955, "Jensen", "Jensen #75", "1960-61", "Jeff46U", "http://www.youtube.com/user/Jeff46u/videos", 2, "In 60 or 61 Jensen came out with their hobby line. As Mr. Jensen never wasted any thing some of the very early 60s had the sight tube so he could use up his older boilers. This is one of them. ", "2014-10-26 19:47:00", 0, "")

        IE(oC, 956, "Line Mar", "Model J-2734", "1960s", "Jeff46U", "http://www.youtube.com/user/Jeff46u/videos", 4, "I believe or is the only model Line Mar I have seen with a copper boiler. All the others had very thing steel boilers. I received this one complete with box and all accessories. Directions are printed on the box. ", "2014-10-26 19:50:00", 0, "")

        IE(oC, 957, "Anton Bohaboy", "Twin Vertical Engine", "c1950s", "Stephen W", "", 4, "This engine much resembles the Stuart D10 yet sitting next to one another, Bohaboy's Twin is appointed nicer and uses heavier material and runs smoother. I own a D10 and as much as it's a fine Engine, I like the Bohaboy better. ", "2014-11-01 14:42:00", 0, "")

        IE(oC, 958, "Rose Boats", "Triton", "2014", "Greenmachine", "", 1, "Single engine pop pop ,candle burner by Alan Raubenheimer of Napier SA ", "2014-11-09 11:02:00", 0, "")

        IE(oC, 959, "Unknown", "#9", "???", "Stephen W", "", 4, "This resembles a Stuart Sun but bigger and heavier. Clearly a Marine plant. Very powerful and heavy.", "2014-12-14 20:45:00", 0, "")

        IE(oC, 960, "Unknown", "#10", "???", "Stephen W", "", 5, "Solid Brass and sheer steel base Horizontal. 1""  bore 1 1/4"" stroke...well made and heavy. (Abt 7lbs) 10"" x 4.5"" x 4""", "2014-12-14 20:51:00", 0, "")

        IE(oC, 961, "Unknown", "#11", "???", "Stephen W", "", 4, "Single Cyl single acting Eccentric valve driven marine type with very unique Reversing unit at the Flywheel. The gears on the flywheel line up to reversing unit gears and turn a double shaft in front of Rev. Box. Lever on top reverses and shafts spin counter to one another.<br>Efficient and very powerful.  7.5""x3.75x3"" 2lbs without reversing unit.", "2014-12-14 20:56:00", 0, "")

        IE(oC, 962, "Bing", "130-311", "1909", "René V", "", 11, "My grandfather bought the steam engine a long time ago and gave it later on to my father.  And he gave it some years ago to me. 45 years ago my father showed me how the engine works.  Since than the machine was hidden on our attic.", "2014-12-14 21:05:00", 0, "")

        IE(oC, 963, "Tony Green", "Steam Plant", "???", "Roly Williams", "http://rolywilliams.com/tony_green_steam_plant.html", 2, "This steam plant uses the USE engine unit.", "2014-12-19 08:03:00", 0, "")

        IE(oC, 964, "Robert Fulton", "Horizontal (Burner fired)", "???", "Roly Williams", "http://www.rolywilliams.com/marvindustries_burner_horiz.html", 2, "Marvindustries  manufactured the Robert Fulton Line of engines", "2014-12-19 08:09:00", 0, "")

        IE(oC, 965, "Marklin", "4149-5", "1916-1930", "Marc Robertson", "http://www.mrphoto.com.au/library/model-steam-engines ", 4, "", "2015-01-04 11:30:00", 0)

        IE(oC, 966, "Wilhelm Bischoff", "#173", "1919", "Stephen W", "", 3, "This Engine is a #173, built in 1919 by Wilhelm Bischoff, while his factory was still in Dresden, Germany. His engines are robust and brilliantly machined. This particular Engine's Dimensions are 13"" x 10 1/4 x 9"" and weighs 30 Lbs. The flywheel is 7"" in diameter. Bore 1.75"" x Stroke 2.0"".", "2015-01-04 11:45:00", 0, "")

        IE(oC, 967, "Wilhelm Bischoff", "#186", "1915", "Stephen W", "", 4, "Here is my other Bischoff. This too was built in Dresden, approx. 1915 and is the largest model engine Bischoff made.<br>It was most certainly used as a power  source for a craftsman of some sort.<br>It's dimensions are 18 3/8"" x 12"" x 7"" and weighs a whopping 55Lbs as the entire base is 3/8"" cast. The flywheel is 6 3/8""....Bore is 2"" x Stroke 2 1/8""<br>It is missing the Flyball Governor which is over 4"" tall itself.", "2015-01-04 11:46:00", 0, "")

        IE(oC, 968, "M. Stauffer", "Sterling Engine", "1975", "Stephen W", "", 5, "I really don't have a lot of provenance on this piece other then the name clearly stamped into it's base and was told it was purchased in Germany about 1975. I was told it was used as a teaching aid and the gentleman I bought it from claimed the builder had a contract with various educational systems throughout The EU, to provide engineering classes and courses with a simple and robust little engine,  although I've never been able to confirm. <br><br>It's dimensions are 10"" x 4 3/4"" x 3 1/2"". Flywheel is 3"" in diameter and the Bore is 3/4"" x Stroke 7/8"" on power piston. 1"" on Displacer rod.<br><br>The design is ingenious. The spirits tank is built into the base where it is filled through one filler cap while the wick sits directly under the displacer housing. A simple removal of the wick cap, light and watch it run.", "2015-01-04 12:06:00", 0, "")

        IE(oC, 969, "Weeden", "Dart plus tender", "1900s", "Lawrence Novak", "", 2, "", "2015-02-14 11:26:00", 0, "")

        IE(oC, 970, "Renown", "Renown 101", "1946-57", "Ozsteamdemon", "", 2, "Australian made from 1946 to `57 when the company went out of business. This engine has had extensive boiler repairs , and filler cap , crank pin bearing and burner are homemade replacements. The engine is currently in running condition, runs well with little condensate, and has recently driven a combined load of several accessories.", "2015-02-14 11:29:00", 0, "")

        IE(oC, 971, "Stuart Turner", "Stuart BB", "c1930s", "Ozsteamdemon", "", 2, "3/4"" X 5/8"" B & S.  Ball raced main bearing.  Brass base frame, homemade", "2015-02-14 11:33:00", 0, "")

        IE(oC, 972, "Bassett Lowke", "Steam Plant with No. 2 Tangye Engine", "c1930s", "David Walmsley", "", 4, "The Steam plants were sold between 1920's to late 1930's. The plant is original play worn condition apart for the steam outlet which had been modified using a condensate pot.   This plant did not have the integral water pump which some had. ", "2015-02-14 11:39:00", 0, "")

        IE(oC, 973, "Wilesco", "D32", "1977", "David Walmsley", "", 3, "This D32 was bought in 1977 by the previous owner.It was used very little and is in near mint condition.", "2015-02-26 18:37:00", 0, "")

        IE(oC, 974, "Stuart Turner", "Stuart Steam Pump", "???", "Ozsteamdemon", "", 1, "Home built from kit, builder and date unknown.  Works reliably well at boiler pressures up to 80 PSI", "2015-02-28 12:55:00", 0, "")

        IE(oC, 975, "Anton Bohaboy", "Horizontal Engine", "1950-61", "Stephen W", "", 5, "This is a very elusive engine, as ""Tony"" Bohaboy mainly built Marine type Engines and castings, (Boilers too) but sold this beauty strictly in Kit form as castings. This is an exemplary example of his ONLY horizontal Engine, aside from the few Hot Air pieces he made as prototypes.<br/><br/>He manufactured them for sale from 1950-61.  He called it the ""Power House""....it is 3/4"" Bore and 1"" Stroke. The castings were made of grey Iron and Bronze, as are most of his Engines. Without base, it weighs 3.5lbs.", "2015-03-03 08:16:00", 0, "")

        IE(oC, 976, "Rose Boats", "Steam pilot boat, Titanic", "1980s-90s", "Alan Raubenheimer", "", 1, "Tin plate with a candle fired diaphragm pop-pop. ", "2015-03-13 07:43:00", 0, "")

        IE(oC, 977, "Rose Boats", "Steam tug, Taurus", "1980s-90s", "Alan Raubenheimer", "", 1, "Tin plate with a candle fired diaphragm pop-pop. ", "2015-03-13 07:44:00", 0, "")

        IE(oC, 978, "Rose Boats", "Steam yacht, Mountain Rose", "1980s-90s", "Alan Raubenheimer", "", 1, "Tin plate with a candle fired diaphragm pop-pop. ", "2015-03-13 07:45:00", 0, "")

        IE(oC, 979, "Rose Boats", "Steam trawler, Cape Rose", "1980s-90s", "Alan Raubenheimer", "", 1, "Tin plate with a candle fired diaphragm pop-pop. ", "2015-03-13 07:46:00", 0, "")

        IE(oC, 980, "Rose Boats", "Steam riverboat, African Rose", "1980s-90s", "Alan Raubenheimer", "", 1, "Tin plate with a candle fired diaphragm pop-pop. ", "2015-03-13 07:47:00", 0, "")

        IE(oC, 981, "Rose Boats", "Steam coaster, Costal Rose", "1980s-90s", "Alan Raubenheimer", "", 1, "Tin plate with a candle fired diaphragm pop-pop. ", "2015-03-13 07:48:00", 0, "")

        IE(oC, 982, "Bassett Lowke", "Marine Plant", "1920s-30s", "Stephen W", "", 5, "The plant is capable of steaming a 2.5'-4' launch. It consists of a standard B&L Meths burner (brass with copper tubing) and Centre Flue Boiler (25cm L x 8.5cm Diameter), boiler and stack are heavy grade Copper and all fittings and stack mount Brass. The engine is a Vertical, single open Cylinder, 1/2"" bore x 5/8"" stroke engine. Very robust and runs at very high RPM's comfortably. The engines dimensions are 6cm H x 5.5cm W with 3.5cm diameter Flywheel. ", "2015-03-13 08:05:00", 0, "")

        IE(oC, 983, "Bing", "Spyder Steam Car", "1902", "Steamin-Dream-Machines Austrailia", "", 1, "", "2015-04-05 23:16:00", 0, "")

        IE(oC, 984, "Powertoy", "Vertical Boiler", "???", "Roly Williams", "http://rolywilliams.com/powertoy_vertical.html", 1, "Powertoy was located in Ontario, Canada. Model name/number is unknown. Date also unknown but guess c1950's", "2015-05-01 08:03:00", 0, "")

        IE(oC, 985, "Maxitrak", "Allchin", "2015", "GaryD", "", 3, "This is a new engine by Maxitrak, Maidstone Engineering. It is a gas fired 3/4 inch scale model of an Allchin Traction engine, built by William Allchin Globe works of Northampton about 1911. This is a powerfull engine capable of pulling scale loads, but will also tick over at slow speed.", "2015-05-06 08:05:00", 0, "")

        IE(oC, 986, "EKT", "Lathe With Dogleg", "1951-1972", "M8Dave", "", 4, "", "2015-05-06 08:10:00", 0, "")

        IE(oC, 987, "EKT", "Column Drill", "1951-1972", "M8Dave", "", 3, "", "2015-05-06 08:15:00", 0, "")

        IE(oC, 989, "Beier", "Serial Number 8", "17-Feb-2015", "maxbykim", "", 1, "This is a beier steam engine serial number 8/25 handcrafted by charles david beier. This particular example was manufactured earlier this year, so this engine is brand new. The boiler is made of copper, while the cylinder is made of brass. There is also an air compressor adapter on this engine. The base reads "" Made by Carl David Beier - 2/17/15""  I purchased this wonderful engine off of ebay.", "2015-07-06 08:15:00", 0, "")

        IE(oC, 990, "Wilhelm Bischoff", "#204", "1908-1924", "Stephen W", "", 1, "This is a #204 engine, (22mm Bore x 25 stroke with 160mm flywheel), it is fitted with a 300mm x 150mm Boiler) with whistle, manometer, pressure gauge and single arm blow out control site glass. All brick Stenciling is original. Note also, three Pully line shaft in same color pattern and design. Entire piece is  27 3/8"" x 17 3/4"" or (648mm x 444mm) long by wide and weighs 14.5kgs.  It was made between 1908 and 1924. It was one of Wilhelm Bischoff's more Aesthetically pleasing plants. And very powerful. One drawback is I do not have original boiler and use a Josef Falk Triple burner which works well but takes the massive boiler 25 minutes to heat to steam at half capacity. This is a large And robust plant made by one of the early German masters who was once Dr. Oskar Schneiders Predecessor. In the mid thirties, Heinrich Rehse took over Wilhelm Bischoff's company and continued to use much of his castings to build very similar. If not the same engines.", "2015-07-13 11:53:00", 0, "")

        IE(oC, 991, "Schoenner", "160-4", "1920s", "Stephen W", "", 5, "This is an early Schoenner model 160/4. Probably made in the early 1920's. You will notice the original burner was replaced with a Faux model of a 55gal drum and piped into the firebox with four wick burner. It is quite realistic looking. I have the original base but kept this as I bought it.  It stands at 17.25"" high, 4.5"" wide and has a 4.25"" flywheel.  It is one of the largest vertical Schoenner's made and runs perfectly. Model includes site glass with drain cocks, operational Flyball governor on pulley, whistle, adjustable weight pressure valve and steam throttle valve. A fine example of early Schoenner craftsmanship.", "2015-07-13 11:59:00", 0, "")

        IE(oC, 992, "Gaselan", "DM2", "1954", "Roly Williams", "http://www.rolywilliams.com/gaselan_dm2.html", 1, "Made in East Germany", "2015-07-18 09:40:00", 0, "")

        IE(oC, 993, "Mamod", "SC3", "1939", "David Walmsley", "", 2, "This rare engine is in original complete condition with box.", "2015-07-18 09:45:00", 0, "")

        IE(oC, 994, "Wilesco", "D12", "1960", "FlyJSH John", "", 5, "Here is my refurbished Wilesco D12 ca. 1960.  She was given to me by a kind member of MamodForums.co.uk who offered it to anyone new to the steam hobby.  When I got her, she needed quite a bit of love.   The filler plug and stack are replacements, and the nickle plating on the boiler was so bad, I chose to take it all the way back to brass.  The last picture is prior to restoration. The refurbishing thread is <a href='http://modelsteam.myfreeforum.org/about82778.html&highlight='>here</a>.", "2015-07-25 17:20:00", 0, "")

        IE(oC, 995, "Wilesco", "D6", "2015", "Swift Fox", "http://swiftfoxsteamco.webs.com/", 2, "One of the smallest engines in the Wilesco range alongside the D2 & D3. ", "2015-08-09 17:30:00", 0, "")

        IE(oC, 996, "Wilesco", "D16", "2015", "Swift Fox", "http://swiftfoxsteamco.webs.com/", 2, "Wilesco’s ‘mid-range’ engine featuring the same engine unit as the D20 but with a slightly smaller flywheel and boiler. My example exhausts to a condensed water tray beneath the chimney which makes it ‘smoke’ when running, interestingly the engine base on mine has the cut out and hole for the old exhaust pipe seen on the earlier examples featured on this page.", "2015-08-09 17:40:00", 0, "")

        IE(oC, 997, "Stuart Turner", "Hammer", "1960s", "Stephen W", "", 6, "This is my early 60's ST Hammer mounted on 1/4"" Aluminum plate and a wood plinth. I had to cut, route and stain the base to have a solid and presentable base for this powerful Hammer. Note the Manual pump oiler Reservoir and drain cock on opposite side of piece. <br>This piece stands 11.5"" tall by 3.75"" wide by 7.5"" long and weighs about 10 Lbs without base. It operated optimally on 30-40psi and can strike a powerful blow to a gentle tap with control of the operating handle.", "2015-08-09 17:50:00", 0, "")

        IE(oC, 998, "Saito", "T2DR", "1970s", "Stephen W", "", 5, "These are very well made marine plants and run extremely smooth at high speeds. I had to do some small restoration and mount the plant as you see it the the engine was perfect. They are small and come standard with Stephenson reversers, which are operated via servo from atop the boiler from a linkage which also acts as the pressure relieve valve.  This engine was made in the 70's, as was the burner and boiler. Boiler capacity, according to small a amount of documentation I got with the pieces, is listed as 693 grams. (Never heard of Boiler capacity listed that way)", "2015-09-07 15:10:00", 0, "")

        IE(oC, 999, "Mamod Accessories", "Grinder", "c1952", "alan_donna", "", 2, "First version Mamod ginder, Featuring a cast iron pedestal which is screwed to the base unlike the later versions with eyelet rivets.  also features the earlier square mounting nuts along with the 2 colour grinding wheels, Model is in totally original condition and boxed. circa 1952 ", "2015-09-16 20:24:00", 0, "")

        IE(oC, 1000, "Mamod Accessories", "WAT", "2000s", "ZZubnik", "", 2, "Water tank accessory", "2015-10-17 11:34:00", -1, "")

        IE(oC, 1001, "Wiggers", "Rider Ericson Waterpump", "2015", "Camst648", "http://camst648.webs.com/", 2, "Rider Ericson waterpump stirling engine scale 1/4.<br/>This exact model is the very last comission model made by Werner Wiggers and the last model he made parts for to this model specificaly. after this model, all production by Mr Wiggers will soly be models made from parts already on store at his workshop. all production will stop before end of this year, 2015.  ", "2015-10-17 11:36:00", 0, "")

        IE(oC, 1002, "Wiggers", "HVB-96-200 Stirling Engine", "2015", "Camst648", "http://camst648.webs.com/", 2, "One of Wiggers best designs. Double deck and double beam, a very mesmerising movement pattern.", "2015-10-17 11:41:00", 0, "")

        IE(oC, 1003, "Wiggers", "HG-96-210-2 Stirling Engine", "2015", "Camst648", "http://camst648.webs.com/", 2, "Special edition classic stirling engine from Werner Wiggers hands. The -2 in the number description indicate this as the special edition of this model with 12cm flywheel compared to the standard 10cm.  The model is also slightly higher and longer then its original cousin (bigger). This engine model is marked nr 19 of the 19 special edition engines ever prodused by Wiggers Modellbau. Production has now ended.", "2015-10-17 11:43:00", 0, "")

        IE(oC, 1004, "Anton Bohaboy", "Twin Marine", "1940-55", "Stephen W", "", 4, "This addition pretty much completes all the engines Anton Bohaboy produced over his 45 years of being in business.<br/>This is his largest Twin Marine with 1"" Bore and 1"" Stroke. Engine is 7 1/2"" x  6 1/2 x 3 1/2 and weighs about 7lbs. This engine was produced bet. 1940-1955 and was primarily used to power a 6'-8' launch.<br/>The incredible craftsmanship Bohaboy possessed allows this engine to run at .20Psi at about 40 RPM's.  Very robust and clearly an engine built to last.", "2015-10-17 11:47:00", 0, "")

        IE(oC, 1005, "Mersey Model Co Ltd", "53", "", "Kevin", "", 3, "", "2015-10-17 12:05:00", 0, "")

        IE(oC, 1006, "Owen", "Owen 2-b", "2015", "Roly Williams", "http://www.rolywilliams.com/Owen%202-b.html", 2, "A twin cylinder engine, obviously inspired by the Mamod SE3", "2015-10-17 12:15:00", 0, "")

        IE(oC, 1007, "Owen", "Owen 68", "2000", "Roly Williams", "http://www.rolywilliams.com/Owen%2068.html", 2, "Single cylinder vertical. This was the prototype for a limited edition of 10.", "2015-10-17 12:18:00", 0, "")

        IE(oC, 1008, "David Auld", "Locomotive", "1966-89", "LukeD", "", 13, "David Auld rear wheel cylinder locomotive that has not been fired.  Have tried it on compressed air, all timing perfect. Quite strong power being a twin cylinder. Can reverse.  Wheels are lead. One rear wheel has some cracking in it. Was hoping a reader may have access to replacement wheel or suggestions on how to repair.  1.3m Round track is currently being cleaned up.   David Auld locomotives are 0 gauge and were made between 1966 to 1989.  This one is of the later design being a square cylinder head.  As I understand only 27 were made with a square cylinder head.  Engine is just shy of 20cm long including front buffers and weighs in at 784 grams  (1 Pound 12 Ounces) empty.", "2015-10-26 22:16:00", 0, "")

        IE(oC, 1009, "Wilesco", "D16-EL", "c1970s", "Roly Williams", "http://www.rolywilliams.com/wilesco_d16-el.html", 2, "This is the electrically heated version of the D16 (220V 300W)", "2016-01-10 20:47:00", 0, "")

        IE(oC, 1010, "Carette", "147-2", "1902-11", "Roly Williams", "http://rolywilliams.com/Georges%20Carette%20147-2.html", 2, "", "2016-01-10 20:51:00", 0, "")

        IE(oC, 1011, "Paul Cooper", "Miniture Stationary", "2015", "Roly Williams", "http://rolywilliams.com/Paul%20Cooper%20stationary.html", 2, "Miniature stationary engine made by Paul Cooper in Ireland", "2016-01-10 20:58:00", 0, "")

        IE(oC, 1012, "MF Steam", "MF Twin", "2011", "Roly Williams", "http://rolywilliams.com/mf_twin.html", 3, "Replica of the Mamod pre-war Minor 2. Number 56 of a limited edition of 100. ", "2016-01-27 20:29:00", 0, "")

        IE(oC, 1013, "CK", "#1", "1950s?", "Roly Williams", "http://rolywilliams.com/ck_1.html", 1, " Very simple brass steam engine made in Japan ", "2016-01-27 20:34:00", 0, "")

        IE(oC, 1014, "Welby", "Steam Boat #1", "2009?", "Roly Williams", "http://rolywilliams.com/welby_steam_board_no1.html", 2, "Pop pop boat", "2016-01-27 20:38:00", 0, "")

        IE(oC, 1015, "Wiggers", "HHV-95-140", "2014", "Camst648", "http://www.camst648.com/", 3, "This is a rather unique stirling engine as it is air cooled, but has no cooling ribbs. Engine is made by Werner Wiggers as the last ever prodused model of this kind. it is under the base marked nr 18 of the 18 made since production start in 1995. The model is perfection all the way from the metal work to the handpainted yellow decor lines.", "2016-01-27 22:38:00", 0, "")

        IE(oC, 1016, "Cotswold Heritage", "Vulcan Steam Plant", "2012", "Camst648", "http://www.camst648.com/", 1, "", "2016-01-27 22:40:00", 0, "")

        IE(oC, 1017, "Mamod Accessories", "Line Shaft", "1940s", "MikeW", "", 2, "Mamod line shaft flat base, circa late 1940s with brass flywheel, found in  nearly mint unused condition. ", "2016-01-27 22:42:00", 0, "")

        IE(oC, 1018, "Mamod", "SW1", "c1978", "MikeW", "", 2, "Mamod SW1 steam wagon, circa 1978, in super condition with quite a few enhancement added.", "2016-01-27 22:44:00", 0, "")


        ' End transaction
        oC.CommitTrans()
        TSB_Generator.Text = "Load is okay.   " & CStr(Now)

    End Sub
    
End Module