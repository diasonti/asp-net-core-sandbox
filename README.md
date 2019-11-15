# Study system

###### Vladimir Danilov CSSE-1601

### Entities: 
1. UserAccount `(Admin, Student)`
2. Course `(many-many with UserAccount)`
3. Class `(many-one Course)`
4. Task `(many-one Class)`
5. TaskGrade `(many-one Task) (many-one UserAccount)`
6. IndividualTask `(many-one UserAccount) (many-one Class)`
7. IndividualTaskGrade `(one-one IndividualTask)`
