
INCLUDE ../Globalvalues/globals.ink

{emotion_state == "": ->main | -> already_chose}

==main==

Hello <color=\#F8FF30>Kurt</color> Kenson, hope you are feeling well?  #speaker:Sheriff #portrait:sheriff_happy #layout:right

i heard you were happy yesterday. is it true? #speaker:Sheriff #layout:right #portrait:sheriff_happy



+[Yes]

    Yes i am, my man. very #layout:left #speaker:Bert #portrait:bert_happy

    Sounds good my friend hope you liked it. <color=\#F8FF30>BIG</color> #portrait:sheriff_happy #layout:right #speaker:Sheriff
    -> done("happy")




+[No]

    Sadly not. Maybe another day #layout:left #speaker:Bert #portrait:bert_sad

    that wasnt that good. Hope you get it soon #portrait:sheriff_sad #layout:right #speaker:Sheriff
    -> done("sad")




+[big happiness]
 whoa whoa there, cowboy. enjoy it #portait:sheriff_sad #layout:right speaker:sad sheriff
->done("bighappy")

    
==done(state)==   
~emotion_state= state
- Fam, go home. you are <color=\#000000>{state}</color> #speaker:bert  #portrait:sheriff_neutral #layout:right

->END

===already_chose===
You are already {emotion_state}
->END