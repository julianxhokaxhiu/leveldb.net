using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace LevelDB
{
    public static class LevelDBInterop
    {
        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern IntPtr LoadLibrary(string lpFileName);

        #region Logger
        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_logger_create(IntPtr /* Action<string> */ logger);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_logger_destroy(IntPtr /* logger*/ option);
        #endregion

        #region DB
        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_open(IntPtr /* Options*/ options, string name, out IntPtr error);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_close(IntPtr /*DB */ db);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_put(IntPtr /* DB */ db, IntPtr /* WriteOptions*/ options, byte[] key, IntPtr keylen, byte[] val, IntPtr vallen, out IntPtr errptr);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_put(IntPtr /* DB */ db, IntPtr /* WriteOptions*/ options, ref int key, IntPtr keylen, int[] val, IntPtr vallen, out IntPtr errptr);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_delete(IntPtr /* DB */ db, IntPtr /* WriteOptions*/ options, byte[] key, IntPtr keylen, out IntPtr errptr);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_write(IntPtr /* DB */ db, IntPtr /* WriteOptions*/ options, IntPtr /* WriteBatch */ batch, out IntPtr errptr);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_get(IntPtr /* DB */ db, IntPtr /* ReadOptions*/ options, byte[] key, IntPtr keylen, out IntPtr vallen, out IntPtr errptr);

        [DllImport("libleveldb", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_get(IntPtr /* DB */ db, IntPtr /* ReadOptions*/ options, ref int key, IntPtr keylen, out IntPtr vallen, out IntPtr errptr);

        [DllImport("libleveldb", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_get(IntPtr /* DB */ db, IntPtr /* ReadOptions*/ options, IntPtr key, IntPtr keylen, out IntPtr vallen, out IntPtr errptr);

        //[DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        //static extern void leveldb_approximate_sizes(IntPtr /* DB */ db, int num_ranges, byte[] range_start_key, long range_start_key_len, byte[] range_limit_key, long range_limit_key_len, out long sizes);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_create_iterator(IntPtr /* DB */ db, IntPtr /* ReadOption */ options);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_create_snapshot(IntPtr /* DB */ db);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_release_snapshot(IntPtr /* DB */ db, IntPtr /* SnapShot*/ snapshot);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_property_value(IntPtr /* DB */ db, string propname);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_repair_db(IntPtr /* Options*/ options, string name, out IntPtr error);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_destroy_db(IntPtr /* Options*/ options, string name, out IntPtr error);

        #region extensions 

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_free(IntPtr /* void */ ptr);

        #endregion


        #endregion

        #region Env
        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_create_default_env();

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_env_destroy(IntPtr /*Env*/ cache);
        #endregion

        #region Iterator
        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_iter_destroy(IntPtr /*Iterator*/ iterator);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte leveldb_iter_valid(IntPtr /*Iterator*/ iterator);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_iter_seek_to_first(IntPtr /*Iterator*/ iterator);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_iter_seek_to_last(IntPtr /*Iterator*/ iterator);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_iter_seek(IntPtr /*Iterator*/ iterator, byte[] key, int length);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_iter_seek(IntPtr /*Iterator*/ iterator, ref int key, int length);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_iter_next(IntPtr /*Iterator*/ iterator);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_iter_prev(IntPtr /*Iterator*/ iterator);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_iter_key(IntPtr /*Iterator*/ iterator, out int length);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_iter_value(IntPtr /*Iterator*/ iterator, out int length);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_iter_get_error(IntPtr /*Iterator*/ iterator, out IntPtr error);
        #endregion

        #region Options
        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_options_create();

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_options_destroy(IntPtr /*Options*/ options);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_options_set_create_if_missing(IntPtr /*Options*/ options, byte o);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_options_set_error_if_exists(IntPtr /*Options*/ options, byte o);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_options_set_info_log(IntPtr /*Options*/ options, IntPtr /* Logger */ logger);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_options_set_paranoid_checks(IntPtr /*Options*/ options, byte o);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_options_set_env(IntPtr /*Options*/ options, IntPtr /*Env*/ env);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_options_set_write_buffer_size(IntPtr /*Options*/ options, long size);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_options_set_max_open_files(IntPtr /*Options*/ options, int max);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_options_set_cache(IntPtr /*Options*/ options, IntPtr /*Cache*/ cache);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_options_set_block_size(IntPtr /*Options*/ options, long size);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_options_set_block_restart_interval(IntPtr /*Options*/ options, int interval);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_options_set_compression(IntPtr /*Options*/ options, int level);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_options_set_comparator(IntPtr /*Options*/ options, IntPtr /*Comparator*/ comparer);
        #endregion

        #region ReadOptions
        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_readoptions_create();

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_readoptions_destroy(IntPtr /*ReadOptions*/ options);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_readoptions_set_verify_checksums(IntPtr /*ReadOptions*/ options, byte o);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_readoptions_set_fill_cache(IntPtr /*ReadOptions*/ options, byte o);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_readoptions_set_snapshot(IntPtr /*ReadOptions*/ options, IntPtr /*SnapShot*/ snapshot);
        #endregion

        #region WriteBatch
        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_writebatch_create();

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_writebatch_destroy(IntPtr /* WriteBatch */ batch);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_writebatch_clear(IntPtr /* WriteBatch */ batch);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_writebatch_put(IntPtr /* WriteBatch */ batch, byte[] key, int keylen, byte[] val, int vallen);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_writebatch_delete(IntPtr /* WriteBatch */ batch, byte[] key, int keylen);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_writebatch_iterate(IntPtr /* WriteBatch */ batch, object state, Action<object, byte[], int, byte[], int> put, Action<object, byte[], int> deleted);
        #endregion

        #region WriteOptions
        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_writeoptions_create();

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_writeoptions_destroy(IntPtr /*WriteOptions*/ options);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_writeoptions_set_sync(IntPtr /*WriteOptions*/ options, byte o);
        #endregion

        #region Cache 
        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_cache_create_lru(int capacity);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_cache_destroy(IntPtr /*Cache*/ cache);
        #endregion

        #region Comparator

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr /* leveldb_comparator_t* */
            leveldb_comparator_create(
            IntPtr /* void* */ state,
            IntPtr /* void (*)(void*) */ destructor,
            IntPtr
            /* int (*compare)(void*,
                              const char* a, size_t alen,
                              const char* b, size_t blen) */
                compare,
            IntPtr /* const char* (*)(void*) */ name);

        [DllImport("libleveldb", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_comparator_destroy(IntPtr /* leveldb_comparator_t* */ cmp);

        #endregion
    }
}