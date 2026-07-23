# Git HOL 4: Conflict Resolution During Merge

## Objectives
- Explain how to resolve conflicts during merge
- Implement conflict resolution when multiple users
  update the same file

## Step 1: Verify Master is Clean
git status

## Step 2: Create a New Branch "GitWork"
git branch GitWork
git checkout GitWork

## Step 3: Add hello.xml in Branch
echo "<hello>Hello from Branch</hello>" > hello.xml
git add hello.xml
git commit -m "Added hello.xml in GitWork branch"

## Step 4: Switch to Master
git checkout master

## Step 5: Add hello.xml in Master (Different Content)
echo "<hello>Hello from Master</hello>" > hello.xml
git add hello.xml
git commit -m "Added hello.xml in master"

## Step 6: Observe Log
git log --oneline --graph --decorate --all

## Step 7: Check Differences
git diff master GitWork

## Step 8: Merge Branch to Master (Conflict will occur)
git merge GitWork

## Step 9: Observe Git Markup (Conflict markers)
cat hello.xml

## Expected Conflict Markup:
## <<<<<<< HEAD
## <hello>Hello from Master</hello>
## =======
## <hello>Hello from Branch</hello>
## >>>>>>> GitWork

## Step 10: Resolve Conflict Manually
## Edit hello.xml and keep the correct content:
## <hello>Hello from Master and Branch - Resolved</hello>

## Step 11: Mark Conflict as Resolved
git add hello.xml

## Step 12: Commit After Conflict Resolution
git commit -m "Resolved merge conflict in hello.xml"

## Step 13: Add Backup File to .gitignore
echo "*.orig" >> .gitignore
git add .gitignore
git commit -m "Add backup files to .gitignore"

## Step 14: Delete Branch After Merge
git branch -d GitWork

## Step 15: Observe Final Log
git log --oneline --graph --decorate

## Key Concepts
- Merge Conflict  — Occurs when same file edited in 2 branches
- <<<<<<< HEAD    — Current branch changes
- =======         — Separator between conflicting changes
- >>>>>>> branch  — Incoming branch changes
- git merge       — Merges and shows conflicts
- git add         — Marks conflict as resolved
- 3-way merge     — Resolves using base, source and target