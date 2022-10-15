VAR health = 3
VAR minotaur = 3
Press Space to continued Dialogue, but use Mouse to Pick Options
Slimely bouncing down the road, you stumble across a monster!
Oh the horror!
-> main

== main ==
    The mighty minotaur stands before you.
    
    The tension in the air is permeated by your slimey jiggle.
    <- action(-> main)
    -> minotaur_act ->
-> DONE

== action (-> ret) ==
    + [Attack!]
        You whip out and lash the minotaur with your slimey tendrils.
        {minotaur == 0:
                -> victory
            - else:
                ~ minotaur -= 1
        }
    + [Speak.] A charitable effort, but slimes don't have vocal chords.
    + [Run.] 
        {RANDOM(0,10) == 0: 
             -> run_away
            - else: 
                You failed to get away...
        }
- -> ret

== minotaur_act ==
    ~ temp attempt = RANDOM(0,5)
    {attempt == 0:
            The fearful minotaur strikes your jelly body with great force. It hurts.
            ~ health -= 1
        - else:
            The minotaur is strong, but his oxen brain does not improve his accuracy as he swings at you and misses.
    }
    {health == 0: -> game_over }
- ->->

== game_over ==
    Defeat doesn't come unexpectedly, I mean you are but a slime... but needless to say the minotaur udderly destroys you. See what I did there?
-> END

== victory == 
    The battle was perilous, but your sliminess has achieved absolute victory!
-> END

== run_away ==
    You got away! Of course a silly minotaur wouldn't be able to keep up with a slime!
-> END