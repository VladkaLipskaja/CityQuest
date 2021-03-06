PGDMP                     	    x        	   cityquest    10.13    12.0 2               0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false                       0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false                       0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false                       1262    16490 	   cityquest    DATABASE     {   CREATE DATABASE cityquest WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'en_US.UTF-8' LC_CTYPE = 'en_US.UTF-8';
    DROP DATABASE cityquest;
                awesomegreensensmaster    false                       0    0    SCHEMA public    ACL     �   REVOKE ALL ON SCHEMA public FROM rdsadmin;
REVOKE ALL ON SCHEMA public FROM PUBLIC;
GRANT ALL ON SCHEMA public TO awesomegreensensmaster;
GRANT ALL ON SCHEMA public TO PUBLIC;
                   awesomegreensensmaster    false    3            �            1259    16491    quests    TABLE     �   CREATE TABLE public.quests (
    id integer NOT NULL,
    name character varying NOT NULL,
    authorid integer NOT NULL,
    topicid integer NOT NULL,
    price integer DEFAULT 0,
    points integer DEFAULT 0
);
    DROP TABLE public.quests;
       public            awesomegreensensmaster    false            �            1259    16499    quests_id_seq    SEQUENCE     �   CREATE SEQUENCE public.quests_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 $   DROP SEQUENCE public.quests_id_seq;
       public          awesomegreensensmaster    false    196                       0    0    quests_id_seq    SEQUENCE OWNED BY     ?   ALTER SEQUENCE public.quests_id_seq OWNED BY public.quests.id;
          public          awesomegreensensmaster    false    197            �            1259    16501    questtouser    TABLE     �   CREATE TABLE public.questtouser (
    questid integer NOT NULL,
    userid integer NOT NULL,
    isfinished boolean DEFAULT false,
    finishedtasks integer DEFAULT 0
);
    DROP TABLE public.questtouser;
       public            awesomegreensensmaster    false            �            1259    16506    tasks    TABLE     Q  CREATE TABLE public.tasks (
    id integer NOT NULL,
    text character varying NOT NULL,
    answer character varying NOT NULL,
    coordinate1 character varying NOT NULL,
    coordinate2 character varying NOT NULL,
    coordinate3 character varying NOT NULL,
    coordinate4 character varying NOT NULL,
    points integer DEFAULT 0
);
    DROP TABLE public.tasks;
       public            awesomegreensensmaster    false            �            1259    16513    task_id_seq    SEQUENCE     �   CREATE SEQUENCE public.task_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 "   DROP SEQUENCE public.task_id_seq;
       public          awesomegreensensmaster    false    199                       0    0    task_id_seq    SEQUENCE OWNED BY     <   ALTER SEQUENCE public.task_id_seq OWNED BY public.tasks.id;
          public          awesomegreensensmaster    false    200            �            1259    16515    tasktoquest    TABLE     w   CREATE TABLE public.tasktoquest (
    questid integer NOT NULL,
    taskid integer NOT NULL,
    tasknumber integer
);
    DROP TABLE public.tasktoquest;
       public            awesomegreensensmaster    false            �            1259    16518    tasktotopic    TABLE     t   CREATE TABLE public.tasktotopic (
    topicid integer NOT NULL,
    taskid integer NOT NULL,
    questid integer
);
    DROP TABLE public.tasktotopic;
       public            awesomegreensensmaster    false            �            1259    16521    topics    TABLE     ]   CREATE TABLE public.topics (
    id integer NOT NULL,
    name character varying NOT NULL
);
    DROP TABLE public.topics;
       public            awesomegreensensmaster    false            �            1259    16527    topics_id_seq    SEQUENCE     �   CREATE SEQUENCE public.topics_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 $   DROP SEQUENCE public.topics_id_seq;
       public          awesomegreensensmaster    false    203                        0    0    topics_id_seq    SEQUENCE OWNED BY     ?   ALTER SEQUENCE public.topics_id_seq OWNED BY public.topics.id;
          public          awesomegreensensmaster    false    204            �            1259    16529    users    TABLE     �   CREATE TABLE public.users (
    id integer NOT NULL,
    login character varying NOT NULL,
    password character varying NOT NULL,
    isadmin boolean DEFAULT false,
    points integer
);
    DROP TABLE public.users;
       public            awesomegreensensmaster    false            �            1259    16536    users_id_seq    SEQUENCE     �   CREATE SEQUENCE public.users_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 #   DROP SEQUENCE public.users_id_seq;
       public          awesomegreensensmaster    false    205            !           0    0    users_id_seq    SEQUENCE OWNED BY     =   ALTER SEQUENCE public.users_id_seq OWNED BY public.users.id;
          public          awesomegreensensmaster    false    206            u           2604    16538 	   quests id    DEFAULT     f   ALTER TABLE ONLY public.quests ALTER COLUMN id SET DEFAULT nextval('public.quests_id_seq'::regclass);
 8   ALTER TABLE public.quests ALTER COLUMN id DROP DEFAULT;
       public          awesomegreensensmaster    false    197    196            y           2604    16539    tasks id    DEFAULT     c   ALTER TABLE ONLY public.tasks ALTER COLUMN id SET DEFAULT nextval('public.task_id_seq'::regclass);
 7   ALTER TABLE public.tasks ALTER COLUMN id DROP DEFAULT;
       public          awesomegreensensmaster    false    200    199            z           2604    16540 	   topics id    DEFAULT     f   ALTER TABLE ONLY public.topics ALTER COLUMN id SET DEFAULT nextval('public.topics_id_seq'::regclass);
 8   ALTER TABLE public.topics ALTER COLUMN id DROP DEFAULT;
       public          awesomegreensensmaster    false    204    203            |           2604    16541    users id    DEFAULT     d   ALTER TABLE ONLY public.users ALTER COLUMN id SET DEFAULT nextval('public.users_id_seq'::regclass);
 7   ALTER TABLE public.users ALTER COLUMN id DROP DEFAULT;
       public          awesomegreensensmaster    false    206    205                      0    16491    quests 
   TABLE DATA           L   COPY public.quests (id, name, authorid, topicid, price, points) FROM stdin;
    public          awesomegreensensmaster    false    196   �:                 0    16501    questtouser 
   TABLE DATA           Q   COPY public.questtouser (questid, userid, isfinished, finishedtasks) FROM stdin;
    public          awesomegreensensmaster    false    198   Q;                 0    16506    tasks 
   TABLE DATA           m   COPY public.tasks (id, text, answer, coordinate1, coordinate2, coordinate3, coordinate4, points) FROM stdin;
    public          awesomegreensensmaster    false    199   n;                 0    16515    tasktoquest 
   TABLE DATA           B   COPY public.tasktoquest (questid, taskid, tasknumber) FROM stdin;
    public          awesomegreensensmaster    false    201   �;                 0    16518    tasktotopic 
   TABLE DATA           ?   COPY public.tasktotopic (topicid, taskid, questid) FROM stdin;
    public          awesomegreensensmaster    false    202   �;                 0    16521    topics 
   TABLE DATA           *   COPY public.topics (id, name) FROM stdin;
    public          awesomegreensensmaster    false    203   <                 0    16529    users 
   TABLE DATA           E   COPY public.users (id, login, password, isadmin, points) FROM stdin;
    public          awesomegreensensmaster    false    205   ,<       "           0    0    quests_id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('public.quests_id_seq', 11, true);
          public          awesomegreensensmaster    false    197            #           0    0    task_id_seq    SEQUENCE SET     9   SELECT pg_catalog.setval('public.task_id_seq', 6, true);
          public          awesomegreensensmaster    false    200            $           0    0    topics_id_seq    SEQUENCE SET     ;   SELECT pg_catalog.setval('public.topics_id_seq', 1, true);
          public          awesomegreensensmaster    false    204            %           0    0    users_id_seq    SEQUENCE SET     ;   SELECT pg_catalog.setval('public.users_id_seq', 35, true);
          public          awesomegreensensmaster    false    206            ~           2606    16543    quests quests_pkey 
   CONSTRAINT     P   ALTER TABLE ONLY public.quests
    ADD CONSTRAINT quests_pkey PRIMARY KEY (id);
 <   ALTER TABLE ONLY public.quests DROP CONSTRAINT quests_pkey;
       public            awesomegreensensmaster    false    196            �           2606    16545    questtouser questtouser_pkey 
   CONSTRAINT     g   ALTER TABLE ONLY public.questtouser
    ADD CONSTRAINT questtouser_pkey PRIMARY KEY (questid, userid);
 F   ALTER TABLE ONLY public.questtouser DROP CONSTRAINT questtouser_pkey;
       public            awesomegreensensmaster    false    198    198            �           2606    16547    tasks task_pkey 
   CONSTRAINT     M   ALTER TABLE ONLY public.tasks
    ADD CONSTRAINT task_pkey PRIMARY KEY (id);
 9   ALTER TABLE ONLY public.tasks DROP CONSTRAINT task_pkey;
       public            awesomegreensensmaster    false    199            �           2606    16549    tasktoquest tasktoquest_pkey 
   CONSTRAINT     g   ALTER TABLE ONLY public.tasktoquest
    ADD CONSTRAINT tasktoquest_pkey PRIMARY KEY (questid, taskid);
 F   ALTER TABLE ONLY public.tasktoquest DROP CONSTRAINT tasktoquest_pkey;
       public            awesomegreensensmaster    false    201    201            �           2606    16551    tasktotopic tasktotopic_pkey 
   CONSTRAINT     g   ALTER TABLE ONLY public.tasktotopic
    ADD CONSTRAINT tasktotopic_pkey PRIMARY KEY (topicid, taskid);
 F   ALTER TABLE ONLY public.tasktotopic DROP CONSTRAINT tasktotopic_pkey;
       public            awesomegreensensmaster    false    202    202            �           2606    16553    topics topics_pkey 
   CONSTRAINT     P   ALTER TABLE ONLY public.topics
    ADD CONSTRAINT topics_pkey PRIMARY KEY (id);
 <   ALTER TABLE ONLY public.topics DROP CONSTRAINT topics_pkey;
       public            awesomegreensensmaster    false    203            �           2606    16555    users users_pkey 
   CONSTRAINT     N   ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (id);
 :   ALTER TABLE ONLY public.users DROP CONSTRAINT users_pkey;
       public            awesomegreensensmaster    false    205            �           2606    16556    quests quests_authorid_fkey    FK CONSTRAINT     {   ALTER TABLE ONLY public.quests
    ADD CONSTRAINT quests_authorid_fkey FOREIGN KEY (authorid) REFERENCES public.users(id);
 E   ALTER TABLE ONLY public.quests DROP CONSTRAINT quests_authorid_fkey;
       public          awesomegreensensmaster    false    205    3722    196            �           2606    16561 $   questtouser questtouser_questid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.questtouser
    ADD CONSTRAINT questtouser_questid_fkey FOREIGN KEY (questid) REFERENCES public.quests(id);
 N   ALTER TABLE ONLY public.questtouser DROP CONSTRAINT questtouser_questid_fkey;
       public          awesomegreensensmaster    false    198    196    3710            �           2606    16566 #   questtouser questtouser_userid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.questtouser
    ADD CONSTRAINT questtouser_userid_fkey FOREIGN KEY (userid) REFERENCES public.users(id);
 M   ALTER TABLE ONLY public.questtouser DROP CONSTRAINT questtouser_userid_fkey;
       public          awesomegreensensmaster    false    205    3722    198            �           2606    16571 $   tasktoquest tasktoquest_questid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.tasktoquest
    ADD CONSTRAINT tasktoquest_questid_fkey FOREIGN KEY (questid) REFERENCES public.quests(id);
 N   ALTER TABLE ONLY public.tasktoquest DROP CONSTRAINT tasktoquest_questid_fkey;
       public          awesomegreensensmaster    false    3710    196    201            �           2606    16576 %   tasktoquest tasktoquest_questid_fkey1    FK CONSTRAINT     �   ALTER TABLE ONLY public.tasktoquest
    ADD CONSTRAINT tasktoquest_questid_fkey1 FOREIGN KEY (questid) REFERENCES public.quests(id);
 O   ALTER TABLE ONLY public.tasktoquest DROP CONSTRAINT tasktoquest_questid_fkey1;
       public          awesomegreensensmaster    false    3710    201    196            �           2606    16581 #   tasktoquest tasktoquest_taskid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.tasktoquest
    ADD CONSTRAINT tasktoquest_taskid_fkey FOREIGN KEY (taskid) REFERENCES public.tasks(id);
 M   ALTER TABLE ONLY public.tasktoquest DROP CONSTRAINT tasktoquest_taskid_fkey;
       public          awesomegreensensmaster    false    201    199    3714            �           2606    16586 #   tasktotopic tasktotopic_taskid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.tasktotopic
    ADD CONSTRAINT tasktotopic_taskid_fkey FOREIGN KEY (taskid) REFERENCES public.tasks(id);
 M   ALTER TABLE ONLY public.tasktotopic DROP CONSTRAINT tasktotopic_taskid_fkey;
       public          awesomegreensensmaster    false    202    3714    199            �           2606    16591 $   tasktotopic tasktotopic_topicid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.tasktotopic
    ADD CONSTRAINT tasktotopic_topicid_fkey FOREIGN KEY (topicid) REFERENCES public.topics(id);
 N   ALTER TABLE ONLY public.tasktotopic DROP CONSTRAINT tasktotopic_topicid_fkey;
       public          awesomegreensensmaster    false    203    202    3720               P   x�3�L,O-��M-,M-.�4�4�4�44�2�!n�静Z�����Z���id�020�2�)c�S����n)Cn����� M`4*            x������ � �         E   x�3�L,O-��M5��,.��σ���S�8�LȀ˔4�f�%��%%���V"X��p��qqq ��&            x�3�4�4�2�1z\\\ �            x������ � �            x�3�LIMK,�)����� #�         )  x���K��:���W��U-� 2�U��(*">�'(#�( ��m=���d������J\�?��'ɏ3M�5LkK�sw�Օ�"��=s��j7��7��N$4m�~��/�'��f��G���s���s!�Wc!!6^Z�
��m5Ū�h�Ŷݷ Q����I��ͱ*���-+em[�������،�A2��rPY�7.�"�5.h���J3جF�~����m��R�_�k~d�k�z.����d�N>i��ZD��G���ڟ%�u��SZ��m7v@W�<Փ��FTn���R�-'�@�f:h�r�wE��K�2�U��n� ���Hʃ���on��F[pH�Kk�Kw�-���9��d����H%�Q�V�}ʡ 4�
B���9P�9�" ˏ������zb纠cNLT���֛���쎾Y�˃�J
J��p��)�g�bI��"`��)YX�A�u,*g9�s�~¾Jťr��=��Ԕ�v��8����\0�����'/�I�~���9��\>�Vpj��>z��?��O�8U����C��))	��v1��ȶ��|*h�^��
�"T8a� p�\%]����DI���a���w�,��,�1�tK�P�=�����R��u}��ah��gN�*C� ��-��K0ύ�$C�����6�Ҡ�@�^�Z�-n���#�!�
,�E�e�~�8�9Kx	����
,�4�1��!(�E|-X
� ��h��"5�������g����{'n6��Ba=����F������!bᅿx�<X4��=�/ֹ~��^�aY�~�z��v�o     