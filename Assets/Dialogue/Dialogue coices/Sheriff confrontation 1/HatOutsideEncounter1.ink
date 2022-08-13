INCLUDE ../Globalvalues/globals.ink

{SheriffBrothersHatEncounter == "": -> main | }




==main==

Hey Kert. Stop right there. Now. #speaker:Sheriff #layout:right #portrait:sheriff_neutral

Is this your hat?

+ [Yes]
    Well i'll be goddamned. That is indeed my hat, Sheriff. Can I have it back? #layout:left #speaker:Kert #portrait:bert_neutral

    -> SheriffTellsBertAboutTheHat

+ [No]
    Sorry Sheriff, I don't recognize that old thing. Musta been some real old hat, rotting away. Though it does seem like it would fit my head. You reckon i can have it?

-> SheriffTellsBertAboutTheHat


==SheriffTellsBertAboutTheHat==

You see, inside of here, I can clearly read that this hat belongs to the infamous criminal Benny.#speaker:Sheriff #layout:right #portrait:sheriff_neutral


And I know that you been wearin' this hat everytime I saw ya. So why dont you tell me the truth of what's going on here, huh, "Kert"? #speaker:Sheriff #layout:right #portrait:sheriff_neutral

-> ChoiceWithSheriff


==ChoiceWithSheriff==



+[Insult him]
    
    -> InsultSheriff



+ [Charm him]

    -> RomanceSheriff




+ [Confess to him]

    ->ConfessToSheriff




==InsultSheriff==

Well... i'll be damned once again. it seems you are right, Sheriff. I am indeed the merciless and infamous criminal Benny. It's real funny though, that you find out after all this damn time.  #speaker:Benny #layout:left #portrait:bert_happy

I've been livin' here for so goddamn long,

and you still didn't realise who I was. What a sheriff you must be, letting someone like me live under your nose in your own town. #speaker:Benny #layout:left #portrait:bert_angry

Now, give me back my hat. #speaker:Benny #layout:left #portrait:bert_angry


{SaloonRobberyEncounter == "ignore": -> IgnoredRobberInsult |-> InsultSheriffWithoutIgnore }

==InsultSheriffWithoutIgnore==

You goddamn shootin' tootin', people robbin', snow shovellin' little criminal. This man right here was right to bring this to me. #speaker:Sheriff #layout:right #portrait:sheriff_angry

Now, you go to your eternal resting place #speaker:Sheriff #layout:right #portrait:sheriff_angry

A standoff? Lets see who can pull the faste- #speaker:Bert #layout:left #portrait:bert_neutral

Light him up! #speaker:Sheriff #layout:right #portrait:sheriff_angry

WAIT! Before you shoot, how am I supposed to survive? I cant get to you fast enough! #speaker:Benny #layout:left #portrait:bert_neutral

->done("barrel")

==IgnoredRobberInsult==

You've been livin' amongst us for all this damn time, would've atleast thought you had some damn decency, but you dont even have that. #speaker:Sheriff #layout:right #portrait:sheriff_angry

You let that robber get away on purpose, didn't ya? The big, scary, master criminal Benny

but you dont even have that hat of yours anymore. I have it. Without it, you are just a tiny man. Litteraly.

Let's finish this fella off!

WAIT! How am i supposed to attack 2 guys with guns without a gun of my own? #speaker:Benny #layout:left #portrait:bert_neutral

->done("barrel")


==RomanceSheriff==

i love you bro #speaker:Benny #layout:left #portrait:bert_happy

I love you too homie #speaker:Sheriff #layout:right #portrait:sheriff_happy

But im taking this hat anyway

->done("romance")




==ConfessToSheriff==

Well Sheriff... might aswell give it up. Yes, i am Benny. I only hid my name so that I could live a peaceful life, since I knew you was gonna #speaker:Benny #layout:left #portrait:bert_sad



be on my tail if I didn't. Im not a criminal, no more. #speaker:Benny #layout:left #portrait:bert_sad

{SaloonRobberyEncounter== "ignore": -> ConfessToSheriffWithIgnore|->ConfessToSheriffWithoutIgnore }

==ConfessToSheriffWithoutIgnore==

 Right. You wouldn't believe the amount of stories i have heard from every kind of criminal there is. But I do see where you're coming from. #speaker:Sheriff #layout:left #portrait:sheriff_happy
 
 And with the hat, you could've easily taken over the entire town. And you were honest with me. Just for that, i am eager to give you a chance. #speaker:Sheriff #layout:left #portrait:sheriff_happy
 
 So, will i be able to get my hat back, buckaroo? #speaker:Benny #layout:left #portrait:bert_happy
 
 I'm sorry partner, im going to need to take it into my safe and find out what to do with it. Until then, it stays locked away.  #speaker:Sheriff #layout:right #portrait:sheriff_neutral
 
 Say goodbye to your hat, Benny. And for yer own sake, stay cool. Or i'll be back, wearin' your hat. #speaker:Sheriff #layout:right #portrait:sheriff_neutral

Hmmmmmm #speaker:Benny #layout:left #portrait:bert_neutral

->done("confess")


==ConfessToSheriffWithIgnore==

Well that all sounds nice and dandy, and i might've even have believed ya, but after seeing you let that criminal go, I just couldn't. #speaker:Sheriff #layout:right #portrait:sheriff_angry

Im sorry it has come to this, partner. I hope those fists of yours can punch me faster than I can shoot a hole through that miscolored shirt. 

And when you're eatin' dirt, maybe I'll put on the hat, live out some of the old days. 

What do you say, scary criminal "Benny" ?

Well, if only I had something to help me fight him... #speaker:Benny #layout:left #portrait:bert_neutral



->done("barrel")



==done(HatOutsideEncounter1)==
~SheriffBrothersHatEncounter = HatOutsideEncounter1

Well, nevermind. #speaker:Benny #layout:left #portrait:bert_happy

Have at thee! 

-> END