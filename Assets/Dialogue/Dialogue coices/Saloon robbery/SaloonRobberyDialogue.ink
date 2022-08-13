INCLUDE ../Globalvalues/globals.ink

{SaloonRobberyEncounter == "": -> main}

===main===

Gimme all the money NOW! This is not a drill, ladies and gentlemen #speaker:Robber #layout:right #portrait:robber_angry

This can all happen very fast and easy, if you cooperate #speaker:Robber #layout:right #portrait:robber_angry

Ey, buckaroos, what is all this, huh? #speaker:Kert #layout:left #portrait:bert_neutral

Leave me alone and you'll survive to tell this story to your chickens one day #speaker:Robber #layout:right #portrait:Default

-> ChoiceMoment

==ChoiceMoment==

+[Stop him by force]

-> StopByForce


+ [Persuade him to stop]

-> PersuadeToStop



+ [Ignore]

-> IgnoreRobber



==StopByForce==

Listen here, you're going to stop robbing this fine establishment now, or i'm gonna have to show you how it's done. What do you say, huh? #speaker:Kert #layout:left #portrait:bert_happy


Really? You have nothing to do? You can't just sit down and enjoy life just a little bit?  #speaker:Robber #layout:right #portrait:Default

Just enjoy a beer or something. But fine, i'll grant you your wish. #speaker:Robber #layout:right #portrait:Default

-> RobberStopped("force")



==PersuadeToStop==

Listen, kid, it sounds like you're not even 25 yet. Look at you. Stealing from this saloon. How low are you, man? Don't you have some other, much more valuable places to rob than whatever you can find in this godforsaken place? #speaker:Kert #layout:left #portrait:bert_neutral

Well... perhaps you're right. Not exactly a bank in here, is it? The amount of bullets i already wasted was probably worth more than I got out of this place. That's it, im done. Have fun and forget this happened. Or i'll come back. #speaker:Robber #layout:right #portrait:Default

->RobberStopped("persuade")



==IgnoreRobber==

Ehhhh fine, have at it. #speaker:Kert #layout:left #portrait:bert_neutral

Heh... that's right. mind your own bussines, and let me mind mine. #speaker:Robber #layout:right #portrait:Default

Hoooooo boy, this is about to be some good money. Oh yeah, im coming back to this place.

Thanks for all this fine beer, Mr. Bartender and fellow drinkers. Have a good one! #speaker:Robber #layout:right #portrait:Default

->RobberStopped("ignore")



==RobberStopped(RobberDecision)
~SaloonRobberyEncounter=RobberDecision

->END


