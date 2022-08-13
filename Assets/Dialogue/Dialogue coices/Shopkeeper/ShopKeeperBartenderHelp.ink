INCLUDE ../Globalvalues/globals.ink


Well well, hello there little man! How may this old fart serve you? #speaker:Shopkeeper #layout:right #portrait:Default

Wait, haven't i just seen you in the saloon? #speaker:Kert #layout:left #portrait:bert_neutral

Well yes and no. Yes because it looked like me, but no since it was not me. It's my goddamn twin brother from the same mother #speaker:Shopkeeper #layout:right #portrait:Default

Well, that's something you dont see everyday. Anyway, he told me to get something from you, good sir. #speaker:Kert #layout:left #portrait:bert_neutral

Oh yea he did, didnt he? Did you ask him if he had plans to pay me this time? Anything? #speaker:Shopkeeper #layout:right #portrait:Default

That's none of my bussines, thats yalls bussines. Now, what is it that he needs? #speaker:Kert #layout:left #portrait:bert_sad

Last we talked he wanted a bucket of milk or somethin', but I dont know if im inclined to give it to 'im this time around. #speaker:Shopkeeper #layout:right #portrait:Default

What you got for me, huh?

+[Convince]

-> ConvinceShopkeeper



+[Charm him]
-> RomanceShopkeeper



+[Act tough]
-> ActTough


==ConvinceShopkeeper==

If you think about it, this is an excellent bussines decision. I get what i want, you don't get what you want and he gets what he wants #speaker:Kert #layout:left #portrait:bert_happy

Wait, that came out wrong... uh, I mean-

Oh goddamn man, you one of the worst bussines men around these parts. Now git out of here before I show you what these hips can do, boy. #speaker:Shopkeeper #layout:right #portrait:Default

Wait partner. Just think about- #speaker:Kert #layout:left #portrait:bert_sad

OUT! Go get my money from that halfsmart ditwit bartender #speaker:Shopkeeper #layout:right #portrait:Default

->END



==RomanceShopkeeper==

Hey hey, there partner, wanna hop in my barrel and do a barrel roll? #speaker:Kert #layout:left #portrait:bert_happy

What kinda cowboy hollerin' was that? If it was actually good you might've left here with a little more than what you want, #speaker:Shopkeeper #layout:right #portrait:Default

but after that line, get out of my shop. Go get my money and then come back, if you dare.

->END

==ActTough==

Listen partner, i'm gonna get what I need for your brother. Wether that means beating it out of you with a broom or by taking it, I am going to get it. #speaker:Kert #layout:left #portrait:bert_sad

Alright alright you unusually small cowboy. Before you go around and punch this crate out under me, just take it. #speaker:Shopkeeper #layout:right #portrait:Default

This bucket right here, is what he wants

->MilkTaken("taken")

==MilkTaken(MilkState)==
~ShopKeeperMilk = MilkState

Good to know that you know how to make a proper deal. Than- #speaker:Kert #layout:left #portrait:bert_neutral

wait, this is milk? What is this? Milk for a bartender? What does a bartender do with milk? #speaker:Kert #layout:left #portrait:bert_sad

How am I supposed to know? Maybe his customers like milk with their wine. People out here are different. #speaker:Shopkeeper #layout:right #portrait:Default

Now take it and git. But bring money next time. 

Don't mistake my willingless for weakness

->END