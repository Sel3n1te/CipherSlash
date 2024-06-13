# CipherSlash
TODO:
Cipher Slash Overview:
[ ] Server
  [w] Connection Handler
    [w] Send/Receive Data
    [ ] Login System
  [ ] User Accounts
    [ ] Username and Password
    [ ] Rounds Played
    [ ] Win/Loss Ratio
    [ ] No. of Ciphers Solved
    [ ] No. of Hints Used
  [ ] Lobby Creation
    [ ] Create a Dedicated Instance
      [ ] room = new Room(inviteCode)?
      [ ] room.addPlayer(client)?
    [ ] Invite Other Players (?)
  [ ] Gameplay Mechanics
    [ ] Given Ciphertext
      [ ] Word/Sentence Generator
      [ ] Randomly Selected Ciphers
      [ ] Difficulty with no. Stages/Round
      [ ] Start with Last Cipher of 'Round'
      [ ] Double-check Validity?
    [ ] Super Simple Cipher Wheel (SSCW)
      [ ] rotateText(rotation)
    [ ] Enigma Machine
      [ ] setWheels(rot1, rot2, rot3)
      [ ] letterPairs("UP", "TO", "FI", "VE")
    [ ] Hints
      [ ] "Stage x has this cipher's key"
      [ ] "Try using the [relevant tool]"
    [ ] Progress
      [ ] Notification for each 'stage'
          completed
      [ ] Let players be wrong?
        [ ] Move back to a previous 'stage'
            to retry a cipher they got wrong?
        [ ] "Player moved back to stage x"
        [ ] Forcing correctness is easier
            but self-doubt is great

[ ] Client
  [ ] Separate display and typing box?
    [ ] Ensures ciphertext stays clearly
        visible even with notifications
    [ ] Gives tool responses in free space
    [ ] Correct text placement with tags
      [ ] "panel:" for Command Panel
      [ ] "display:" for Game Display

Key:
[ ]  Not started yet
[w]  Work In Progress
[x]  Completed
