Well, there you are. Goodmorning to you, Kurt. Been a rough night, huh? #speaker:Bartender #layout:right #portrait:Default

That's putting it mildly. I think I remember kicking an armadillo sometime, but im not sure about it... #speaker:Kert #layout:left #portrait:bert_neutral

Anyway, did I hit the chair over that fat one's head again, like last time? 

Oh you sure did. But he is a bit of an annoyance 'round here, so im fine with that. He would drink all my aged wine and not pay a dime. #speaker:Bartender #layout:right #portrait:Default

Well, in that case, glad to be of service. Now, i need to- #speaker:Kert #layout:left #portrait:bert_neutral

Wait a minute, my head is a bit too light. Where in the name of the almighty lasso is my hat?

That old raggedy hat that looks older than my Ma? Yeah sure, you had it on ya yesterday night. Then ya slept, and woke up like that. #speaker:Bartender #layout:right #portrait:Default

So you tellin' me I had it on yesterday night and then I didn't this morning? #speaker:Kert #layout:left #portrait:bert_neutral
 ->Questions

==Questions==

+[Ask about hat]
 -> AskAboutHat

+[Ask about customers yesterday]
-> CustomersYesterday

* [Useless question]

-> UselessQuestion




==AskAboutHat==

Hey, you didnt see my hat somewhere in here, did ya? #speaker:Kert #layout:left #portrait:bert_neutral

Well, as I said, you had it on ya. But I did see a strange feller enter while you were sleepin'. Dont know if he had anything to do with that. #speaker:Bartender #layout:right #portrait:Default

Tell me what he looked like. #speaker:Kert #layout:left #portrait:bert_angry

-> ShopkeeperQuestStart



==CustomersYesterday==

Did you see anyone looking suspicious yesterday night, while I was sleeping? #speaker:Kert #layout:left #portrait:bert_neutral

Yeah sure, strange types come in all the damn time. But i did see a feller yesterday who looked a tad bit stranger than usual #speaker:Bartender #layout:right #portrait:Default

What did this feller look like? #speaker:Kert #layout:left #portrait:bert_angry

->ShopkeeperQuestStart



==UselessQuestion==

Did I spend too much money again? #speaker:Kert #layout:left #portrait:bert_neutral

Every last dime. #speaker:Bartender #layout:right #portrait:Default 

Damn... im gonna have to stop coming in here #speaker:Kert #layout:left #portrait:bert_neutral

->Questions



==ShopkeeperQuestStart==

Well, ya see, I would like to help you, but the fact of the matter is, im going to need something from you back #speaker:Bartender #layout:right #portrait:Default

for destroying all them bottles and attacking my customer yesterday. I'm gonna need you to go to the general store up the road, with the 2 big signs of a sack.

Go talk to the shopkeeper, he knows what I need.

-> END




